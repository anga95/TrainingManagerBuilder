using System.Diagnostics;

namespace TrainingManagerBuilder;

public abstract class Builder : IBuilder
{
    protected string solutionPath;
    protected string projectName;
    private Stopwatch stopwatch;

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
                        // Logga endast varningar och fel
                        if (line.Contains("warning") || line.Contains("error"))
                        {
                            Logger.Log(line);
                        }
                    }
                }

                using (StreamReader errorReader = process.StandardError)
                {
                    string errorResult = errorReader.ReadToEnd();
                    if (!string.IsNullOrEmpty(errorResult))
                    {
                        Logger.LogError(errorResult);
                    }
                }

                process.WaitForExit(10000); // Väntar i 10 sekunder
                if (!process.HasExited)
                {
                    Logger.Log($"MSBuild process is still running after 10 seconds. Attempting to kill the process.");
                    process.Kill();
                }

                // Kontrollera om processen avslutades med en felkod
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