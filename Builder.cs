using System.Diagnostics;

namespace TrainingManagerBuilder;

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

            string msbuildPath = "C:\\Program Files\\Microsoft Visual Studio\\2022\\Enterprise\\MSBuild\\Current\\Bin\\MSBuild.exe";
            string arguments = $"\"{solutionPath}\" /t:Rebuild /p:Configuration=Release /p:ProjectName={projectName}";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = msbuildPath,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("warning") || line.Contains("error"))
                        {
                            //Logger.Log(line);
                        }
                    }
                }

                using (StreamReader errorReader = process.StandardError)
                {
                    string errorResult = errorReader.ReadToEnd();
                    if (!string.IsNullOrEmpty(errorResult))
                    {
                        //Logger.LogError(errorResult);
                    }
                }

                int waitTimer = 5000;
                process.WaitForExit(waitTimer);
                if (!process.HasExited)
                {
                    Logger.Log($"MSBuild process is still running after {(waitTimer / 1000)} seconds. Attempting to kill the process.");
                    process.Kill();
                }

                // Check if MSBuild failed
                if (process.ExitCode != 0)
                {
                    Logger.LogError($"MSBuild failed with exit code: {process.ExitCode}");
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