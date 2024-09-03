using System.Diagnostics;

namespace TrainingManagerBuilder.Builders;

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

            string msbuildPath = FindMSBuildPath();
            string arguments = $"\"{solutionPath}\" /t:Rebuild /p:Configuration=Release /p:ProjectName={projectName}";

            // RedirectStandardOutput and RedirectStandardError are not used because MSBuild output is too verbose
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
                process.WaitForExit(); // Wait for the process to exit

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

    public static string FindMSBuildPath()
    {
        var settings = UserSettings.LoadSettings();
        if (!string.IsNullOrEmpty(settings.MSBuildPath) && File.Exists(settings.MSBuildPath))
        {
            Logger.Log($"Using saved MSBuild path: {settings.MSBuildPath}");
            return settings.MSBuildPath;
        }

        // Try to find MSBuild in PATH, if present use it.
        string msbuildInPath = FindMSBuildInPath();
        if (!string.IsNullOrEmpty(msbuildInPath))
        {
            settings.MSBuildPath = msbuildInPath;
            settings.SaveSettings();
            return msbuildInPath;
        }

        // If MSBuild is not found in PATH, try to find it in common installation paths
        List<string> potentialPaths = new List<string>
        {
            @"C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe",
            @"C:\Program Files (x86)\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe",
            @"C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe",
            @"C:\Program Files (x86)\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe",
            @"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe",
            @"C:\Program Files (x86)\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe",
            @"C:\Program Files\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe",
            @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe",
            @"C:\Program Files\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe",
            @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe",
            @"C:\Program Files\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe",
            @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
        };

        foreach (string path in potentialPaths)
        {
            if (File.Exists(path))
            {
                Logger.Log($"MSBuild found at: {path}");
                settings.MSBuildPath = path;
                settings.SaveSettings();
                return path;
            }
        }

        // If MSBuild is not found in common installation paths, ask the user to locate it
        MessageBox.Show("Could not find MSBuild.exe. Please select the correct MSBuild.exe file.", "MSBuild Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Title = "Select MSBuild.exe",
            Filter = "MSBuild.exe|MSBuild.exe",
            InitialDirectory = @"C:\Program Files\"
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            settings.MSBuildPath = openFileDialog.FileName;
            settings.SaveSettings();
            return openFileDialog.FileName;
        }

        throw new FileNotFoundException("MSBuild.exe could not be located.");
    }


    public static string FindMSBuildInPath()
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "MSBuild.exe",
                Arguments = "/version",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string output = reader.ReadToEnd();
                    if (process.ExitCode == 0 && output.Contains("Microsoft (R) Build Engine"))
                    {
                        return "MSBuild.exe";
                    }
                }
            }
        }
        catch (Exception)
        {
            //Logger.LogError("MSBuild not found in PATH.");
        }

        return null;
    }




    public abstract void Clean();
}