using System;
using System.Diagnostics;
using System.IO;


public abstract class Builder : IBuilder
{
    protected string solutionPath;
    protected string projectName;


    public Builder(string solutionPath, string projectName)
    {
        this.solutionPath = solutionPath;
        this.projectName = projectName;
    }

    public virtual void Build()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        try
        {
            Logger.LogNewSection($"Starting build for project: {projectName}");

            var settings = UserSettings.Instance;
            string msbuildPath = settings.MSBuildPath;

            if (string.IsNullOrEmpty(msbuildPath))
            {
                throw new FileNotFoundException("MSBuild path is not set or invalid.");
            }

            string arguments = $"\"{solutionPath}\" /t:Rebuild /p:Configuration=Release /p:ProjectName={projectName}";

            // RedirectStandardOutput and RedirectStandardError are not used because MSBuild output is too verbose.
            // Only use this if you want to capture the output/debug.
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = msbuildPath,
                Arguments = arguments,
                //RedirectStandardOutput = true,
                //RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    Logger.Log($"MSBuild exit code: {process.ExitCode}");
                }
            }


            stopwatch.Stop();
            Logger.Log($"Build for project {projectName} completed successfully in {stopwatch.Elapsed.TotalSeconds} seconds.");
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            Logger.LogError($"Build for project {projectName} failed after {stopwatch.Elapsed.TotalSeconds} seconds. Error: {ex.Message}");
        }
    }
    public abstract void Clean();
}