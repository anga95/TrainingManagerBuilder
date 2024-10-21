using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainingManagerBuilder;

public class BuildManager
{
    private readonly string sourcePath;
    private readonly string outputDirectory;
    private readonly string newVersionNumber;
    private readonly string oldVersionNumber;
    private readonly ZipUtilities zipUtilities;
    private readonly Dictionary<string, ProgressStepManager> progressSteps;

    private Project tm;
    private Project web;
    private Project installer;

    private VersionManager versionManager;

    public BuildManager(string sourcePath,
        Dictionary<string, ProgressStepManager> progressSteps,
        string outputDirectory,
        string newVersionNumber,
        string oldVersionNumber)
    {
        if (string.IsNullOrWhiteSpace(sourcePath))
            throw new ArgumentException("Source path cannot be null or empty.", nameof(sourcePath));
        this.sourcePath = sourcePath;

        if (string.IsNullOrWhiteSpace(outputDirectory))
            throw new ArgumentException("Output directory cannot be null or empty.", nameof(outputDirectory));
        this.outputDirectory = CreateOutputDirectory(outputDirectory, newVersionNumber);

        this.progressSteps = progressSteps;
        this.newVersionNumber = newVersionNumber;
        this.oldVersionNumber = oldVersionNumber;

        this.zipUtilities = new ZipUtilities();
        versionManager = new VersionManager(sourcePath);


        tm = new Project(Project.ProjectType.TM, sourcePath, outputDirectory, newVersionNumber, oldVersionNumber);
        web = new Project(Project.ProjectType.Web, sourcePath, outputDirectory, newVersionNumber, oldVersionNumber);
        installer = new Project(Project.ProjectType.TMInstaller, sourcePath, outputDirectory, newVersionNumber, oldVersionNumber);


    }

    public async Task<bool> BuildAndPackage()
    {
        SetTimersToWaiting();
        ResetProgressBars();
        Stopwatch totalStopwatch = new Stopwatch();
        totalStopwatch.Start();

        try
        {
            KillAllMSBuildProcesses();

            // Step 1: Update version in files
            bool updateVersionsSuccess = await UpdateVersionInFilesAsync(newVersionNumber, progressSteps["UpdateFileVersions"]);
            if (!updateVersionsSuccess)
            {
                throw new Exception("Version update failed");
            }

            // Step 2 BuildAsync and zip TM Reports Website
            bool tmWebsiteBuildSuccess = await BuildAndZipProjectAsync(web, progressSteps["BuildWeb"]);
            if (!tmWebsiteBuildSuccess)
            {
                throw new Exception("TM Reports Website Build failed");
            }

            // Step 3: BuildAsync and zip TM
            bool tmBuildSuccess =
                await BuildAndZipProjectAsync(tm, progressSteps["BuildTM"]);
            if (!tmBuildSuccess)
            {
                throw new Exception("TM Build failed");
            }

            // Step 4: Replace zip files in TMInstaller
            bool replaceZipsSuccess = await ReplaceInstallerZipFilesAsync(oldVersionNumber, progressSteps["copyZips"]);
            if (!replaceZipsSuccess)
            {
                throw new Exception("zip file replacement in installer failed");
            }

            // Step 5: BuildAsync and zip TM installer
            bool tmInstallerBuildSuccess =
                await BuildAndZipProjectAsync(installer, progressSteps["BuildInstaller"]);
            if (!tmInstallerBuildSuccess)
            {
                throw new Exception("TM installer Build failed");
            }


            // Step 6: Add Release Notes
            await Task.Run(() => AddReleaseNotes());

            totalStopwatch.Stop();
            Logger.Log($"BuildAsync, package, and installer update completed successfully in {totalStopwatch.Elapsed.TotalMinutes:F2} minutes.");
            return true;
        }
        catch (Exception ex)
        {
            totalStopwatch.Stop();
            Logger.LogError($"BuildAsync and package process failed after {totalStopwatch.Elapsed.TotalMinutes:F2} minutes. Error: {ex.Message}");
            return false;
        }
    }

    private static string CreateOutputDirectory(string outputDirectory, string newVersion)
    {
        string versionOutputDirectory = Path.Combine(outputDirectory, newVersion);
        if (!Directory.Exists(versionOutputDirectory))
        {
            Directory.CreateDirectory(versionOutputDirectory);
        }

        return versionOutputDirectory;
    }

    private async Task<bool> UpdateVersionInFilesAsync(string newVersion, ProgressStepManager step)
    {
        Logger.LogNewSection("Updating version in files");
        try
        {
            step.Start();
            await versionManager.UpdateVersionInFilesAsync(newVersion, progressSteps["UpdateFileVersions"].ProgressBar);
            step.Stop();
            return true;

        }
        catch (Exception ex)
        {
            Logger.LogError($"Version update failed: {ex.Message}");
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    private async Task<bool> BuildAndZipProjectAsync(Project project, ProgressStepManager stepManager)
    {
        try
        {
            stepManager.Start(100);
            if (project.Type == Project.ProjectType.TMInstaller)
            {
                project.Builder.DeleteInstallerBinDirectory();
            }

            stepManager.SetProgress(10);
            stepManager.UpdateStatus("Building...");
            bool buildSuccess = await project.Builder.BuildAsync();
            if (!buildSuccess)
            {
                stepManager.Failed();
                Logger.LogError($"Build failed for {project.Name}");
                return false;
            }
            stepManager.SetProgress(50);
            stepManager.UpdateStatus("Zipping...");
            bool zipSuccess = await zipUtilities.ZipDirectoryAsync(project);
            if (!zipSuccess)
            {
                stepManager.Stop();
                Logger.LogError($"Zipping of {project.ZipFileInOutputDirectory.Path} failed");
                return false;
            }

            stepManager.SetProgress(100);

            stepManager.Stop();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }

    }

    private async Task<bool> ReplaceInstallerZipFilesAsync(string oldVersion, ProgressStepManager stepManager)
    {
        stepManager.Start(2);

        try
        {
            bool replaceTMSuccess = await zipUtilities.ReplaceZipFileAsync(installer.ProjectDirectory, tm);
            if (!replaceTMSuccess)
            {
                stepManager.Stop();
                Logger.LogError($"TM zip file replacement failed");
                return false;
            }
            stepManager.SetProgress(1);


            bool replaceWebSuccess = await zipUtilities.ReplaceZipFileAsync(installer.ProjectDirectory, web);
            if (!replaceWebSuccess)
            {
                stepManager.Stop();
                Logger.LogError($"TM Reports Website zip file replacement failed");
                return false;
            }

            stepManager.SetProgress(2);
            stepManager.Stop();
            return true;
        }
        catch
        {
            stepManager.Stop();
            Logger.LogError("Error replacing zip files in installer");
            return false;
        }
    }

    private void AddReleaseNotes()
    {
        try
        {
            string releaseNotesSourcePath = Path.Combine(sourcePath, "TMInstaller", "Documents", "Training Manager Release Notes.txt");
            string releaseNotesTargetPath = Path.Combine(outputDirectory, "Training Manager Release Notes.txt");

            if (!File.Exists(releaseNotesTargetPath) && File.Exists(releaseNotesSourcePath))
            {
                File.Copy(releaseNotesSourcePath, releaseNotesTargetPath);
                Logger.Log("Release notes added to output directory.");
            }
            else
            {
                Logger.Log("Release notes already exist or source file is missing.");
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error adding release notes: {ex.Message}");
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
