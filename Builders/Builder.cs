using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

public class Builder
{
    protected string sourcePath;
    protected string projectFilePath;
    protected string configuration = "Release";
    protected string buildMode = "Rebuild";
    protected string platform = "AnyCPU";

    public string ProjectName => Path.GetFileNameWithoutExtension(projectFilePath);

    public Builder(string sourcePath, string projectFilePath)
    {
        this.sourcePath = sourcePath;
        this.projectFilePath = projectFilePath;
    }

    public virtual async Task<bool> BuildAsync()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        try
        {
            Logger.LogNewSection($"Starting build for project: {ProjectName}");

            // Use MSBuild from Visual Studio 2017
            UserSettings settings = UserSettings.Instance;
            string msbuildExePath = settings.MSBuildPath;
            if (!File.Exists(msbuildExePath))
            {
                throw new FileNotFoundException("MSBuild path is not set or invalid.", msbuildExePath);
            }

            // Prepare MSBuild arguments
            string trimmedSourcePath = sourcePath.TrimEnd('\\');
            string solutionDir = trimmedSourcePath + @"\\";

            string arguments = $"\"{projectFilePath}\" /t:{buildMode} /p:Configuration={configuration};Platform=\"{platform}\";VisualStudioVersion=15.0;SolutionDir=\"{solutionDir}\" /v:diag";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = msbuildExePath,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Path.GetDirectoryName(projectFilePath),
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();

                var outputTask = process.StandardOutput.ReadToEndAsync();
                var errorTask = process.StandardError.ReadToEndAsync();

                await Task.Run(() => process.WaitForExit()); stopwatch.Stop();

                // Wait for the output and error streams to complete
                string output = await outputTask;
                string error = await errorTask;

                if (process.ExitCode == 0)
                {
                    Logger.Log($"Build for project {ProjectName} completed successfully in {stopwatch.Elapsed.TotalSeconds:F2} seconds.");
                    return true;
                }
                else
                {
                    string logFilePath = Path.Combine(Path.GetDirectoryName(projectFilePath), "build.log");
                    File.WriteAllText(logFilePath, output + Environment.NewLine + error);
                    Logger.LogError($"Build failed with exit code {process.ExitCode}.");
                    Logger.LogError($"Build output written to {logFilePath}");
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            Logger.LogError($"BuildAsync for project {ProjectName} failed after {stopwatch.Elapsed.TotalSeconds:F2} seconds. Exception: {ex.Message}");
            return false;
        }
    }
    public void DeleteInstallerBinDirectory()
    {
        string projectDirectory = Path.Combine(sourcePath, "TMInstaller");
        string binPath = Path.Combine(projectDirectory, "bin");

        if (Directory.Exists(binPath))
        {
            Directory.Delete(binPath, true);
            Logger.Log("Deleted bin folder in TMInstaller");
        }
    }
}