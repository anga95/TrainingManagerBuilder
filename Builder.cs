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
                    string result = reader.ReadToEnd();
                    //Logger.Log(result);
                }

                using (StreamReader errorReader = process.StandardError)
                {
                    string errorResult = errorReader.ReadToEnd();
                    if (!string.IsNullOrEmpty(errorResult))
                    {
                        //Logger.LogError(errorResult);
                    }
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