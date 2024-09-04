using System.Diagnostics;
using TrainingManagerBuilder.Builders;
using TrainingManagerBuilder.Utilities;

public class BuildManager
{
    private readonly string solutionPath;
    private readonly ZipUtilities zipUtilities;
    private readonly Dictionary<string, ProgressStepManager> progressSteps;
    private IBuilder tmBuilder;
    private IBuilder tmWebsiteBuilder;
    private IBuilder tmInstallerBuilder;
    private VersionManager versionManager;

    public BuildManager(string solutionPath, ZipUtilities zipUtilities, Dictionary<string, ProgressStepManager> progressSteps)
    {
        this.solutionPath = solutionPath;
        this.zipUtilities = zipUtilities;
        this.progressSteps = progressSteps;

        tmBuilder = new BuildTM(solutionPath);
        tmWebsiteBuilder = new BuildWebsite(solutionPath);
        tmInstallerBuilder = new BuildTMInstaller(solutionPath);
        versionManager = new VersionManager(solutionPath);
    }

    public async Task BuildAndPackage(string outputDirectory, string sourcePath, string oldVersion, string newVersion)
    {
        SetTimersToWaiting();
        ResetProgressBars();
        Stopwatch totalStopwatch = new Stopwatch();
        totalStopwatch.Start();

        try
        {
            KillAllMSBuildProcesses();

            // Step 1: Update version in files
            Logger.LogNewSection("Updating version in files");
            try
            {
                var updateFilesStep = progressSteps["UpdateFileVersions"];
                updateFilesStep.Start();
                await UpdateVersionInFiles(newVersion);
                updateFilesStep.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Logger.LogNewSection("Starting the Build and Package process");

            string versionOutputDirectory = Path.Combine(outputDirectory, newVersion);
            if (!Directory.Exists(versionOutputDirectory))
            {
                Directory.CreateDirectory(versionOutputDirectory);
            }


            // Step 2: Build and zip TM
            var tmStep = progressSteps["BuildTM"];
            tmStep.Start(2);
            string tmReleasePath = Path.Combine(sourcePath, @"bin\Release");
            string tmZipPath = await Task.Run(() =>
                BuildAndZipProject(tmBuilder, tmReleasePath, versionOutputDirectory, $"TM {newVersion}.zip", tmStep)
            );
            tmStep.Stop();

            // Step 3 Build and zip TM Reports Website
            var webStep = progressSteps["BuildWeb"];
            webStep.Start(2);
            string websiteReleasePath = Path.Combine(sourcePath, @"TMReportsWebsite");
            string websiteZipPath = await Task.Run(() =>
                BuildAndZipProject(tmWebsiteBuilder, websiteReleasePath, versionOutputDirectory, $"TM Reports Website {newVersion}.zip", webStep)
            );
            webStep.Stop();

            // Step 4: Replace zip files in TMInstaller
            var copyStep = progressSteps["copyZips"];
            copyStep.Start(2);
            await Task.Run(() => ReplaceInstallerZipfiles(sourcePath, tmZipPath, oldVersion, newVersion, websiteZipPath, copyStep));
            copyStep.Stop();

            // Step 5: Build and zip TM Installer
            var installerStep = progressSteps["BuildInstaller"];
            installerStep.Start(2);
            string installerReleasePath = Path.Combine(sourcePath, @"TMInstaller\bin\Release");
            await Task.Run(() =>
                BuildAndZipProject(tmInstallerBuilder, installerReleasePath, versionOutputDirectory, $"TM Installer {newVersion}.zip", installerStep)
            );
            installerStep.Stop();

            // Step 6: Add Release Notes
            await Task.Run(() => AddReleaseNotes(sourcePath, versionOutputDirectory));

            totalStopwatch.Stop();
            Logger.Log($"Build, package, and installer update completed successfully in {totalStopwatch.Elapsed.TotalMinutes:F2} minutes.");
        }
        catch (Exception ex)
        {
            totalStopwatch.Stop();
            Logger.LogError($"Build and package process failed after {totalStopwatch.Elapsed.TotalMinutes:F2} minutes. Error: {ex.Message}");
            throw;
        }
    }
    private async Task UpdateVersionInFiles(string newVersion)
    {
        try
        {
            await versionManager.UpdateVersionInFilesAsync(newVersion, progressSteps["UpdateFileVersions"].ProgressBar);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task<string> BuildAndZipProject(IBuilder builder, string releasePath, string outputDirectory, string zipFileName, ProgressStepManager stepManager)
    {
        builder.Build();
        stepManager.SetProgress(1);

        string zipPath = Path.Combine(outputDirectory, zipFileName);
        await Task.Run(() => zipUtilities.ZipDirectory(releasePath, zipPath));
        stepManager.SetProgress(2);

        return zipPath;
    }

    private async Task ReplaceInstallerZipfiles(string sourcePath, string tmZipPath, string oldVersion, string newVersion, string websiteZipPath, ProgressStepManager stepManager)
    {
        string installerPath = Path.Combine(sourcePath, @"TMInstaller");

        await Task.Run(() => zipUtilities.ReplaceZipFile(installerPath, tmZipPath, oldVersion, newVersion, $"TM"));
        stepManager.SetProgress(1);
        await Task.Run(() => zipUtilities.ReplaceZipFile(installerPath, websiteZipPath, oldVersion, newVersion, $"TM Reports Website"));
        stepManager.SetProgress(2);
    }

    private void AddReleaseNotes(string sourcePath, string versionOutputDirectory)
    {
        string releaseNotesSourcePath = Path.Combine(sourcePath, "TMInstaller", "Documents", "Training Manager Release Notes.txt");
        string releaseNotesTargetPath = Path.Combine(versionOutputDirectory, "Training Manager Release Notes.txt");

        if (!File.Exists(releaseNotesTargetPath) && File.Exists(releaseNotesSourcePath))
        {
            File.Copy(releaseNotesSourcePath, releaseNotesTargetPath);
        }
    }

    private void KillAllMSBuildProcesses()
    {
        var runningProcesses = Process.GetProcessesByName("MSBuild");
        if (runningProcesses.Length > 0)
        {
            Logger.Log("Killing all running MSBuild processes...");

            foreach (var process in runningProcesses)
            {
                try
                {
                    process.Kill();
                    Logger.Log($"MSBuild process (PID: {process.Id}) terminated.");
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Failed to terminate MSBuild process (PID: {process.Id}): {ex.Message}");
                }
            }

            Logger.Log("All MSBuild processes have been terminated.");
        }
        else
        {
            Logger.Log("No MSBuild processes were running.");
        }
    }

    private void ResetProgressBars()
    {
        foreach (var step in progressSteps.Values)
        {
            step.ResetProgressBar();
        }
    }

    private void SetTimersToWaiting()
    {
        foreach (var step in progressSteps.Values)
        {
            step.SetWaiting();
        }
    }

    private void CheckAndWaitForOtherProcesses()
    {
        var runningProcesses = Process.GetProcessesByName("MSBuild");
        if (runningProcesses.Length > 0)
        {
            Logger.Log("Another MSBuild process is running. Waiting for it to finish...");

            foreach (var process in runningProcesses)
            {
                process.WaitForExit();
            }

            Logger.Log("MSBuild process finished. Continuing...");
        }
    }
}
