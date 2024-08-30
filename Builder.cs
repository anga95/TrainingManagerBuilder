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
        //string msbuildPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MSBuildTools", "MSBuild.exe");
        string msbuildPath = "C:\\Program Files\\Microsoft Visual Studio\\2022\\Enterprise\\MSBuild\\Current\\Bin\\MSBuild.exe";

        // Lägg till projektnamnet för att bygga ett specifikt projekt
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
                Console.WriteLine(result);
            }

            using (StreamReader errorReader = process.StandardError)
            {
                string errorResult = errorReader.ReadToEnd();
                if (!string.IsNullOrEmpty(errorResult))
                {
                    Console.WriteLine($"Error: {errorResult}");
                }
            }
        }
    } // "C:\valmet\TrainingManagerBuilder\MSBuildTools\MSBuild.exe" "C:\valmet\TM\TM_new\Dev\source\TrainingManager.sln" /t:Rebuild /p:Configuration=Release /p:ProjectName=TMInstaller


    public abstract void Clean();
}