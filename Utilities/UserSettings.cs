using Newtonsoft.Json;
using System.Diagnostics;
using JsonFormatting = Newtonsoft.Json.Formatting;

public class UserSettings
{
    public bool OpenOutputDirectoryAfterBuild { get; set; }
    public bool OpenTortoiseGitAfterBuild { get; set; }

    private string msbuildPath;
    private string tortoiseGitPath;

    private UserSettings(){}

    #region Singleton
    private static readonly object lockObject = new object();
    private static UserSettings instance;

    public static UserSettings Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = LoadSettings();
                    }
                }
            }
            return instance;
        }
    }
    #endregion

    #region Settings Loading/Saving
    public static string ConfigFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userSettings.json");

    private static UserSettings LoadSettings()
    {
        if (File.Exists(ConfigFilePath))
        {
            string json = File.ReadAllText(ConfigFilePath);
            return JsonConvert.DeserializeObject<UserSettings>(json);
        }

        return new UserSettings();  // Return default settings if file does not exist
    }

    public void SaveSettings()
    {
        string json = JsonConvert.SerializeObject(this, JsonFormatting.Indented);
        File.WriteAllText(ConfigFilePath, json);
    }
    #endregion

    #region MSBuild
    public string MSBuildPath
    {
        get
        {
            if (!string.IsNullOrEmpty(msbuildPath) && File.Exists(msbuildPath))
            {
                Logger.Log($"Using saved MSBuild path: {msbuildPath}");
                return msbuildPath;
            }

            msbuildPath = FindMSBuildPath();
            if (!string.IsNullOrEmpty(msbuildPath))
            {
                SaveSettings();
            }
            return msbuildPath;
        }
        set
        {
            msbuildPath = value;
            SaveSettings();
        }
    }

    private string FindMSBuildPath()
    {
        if (!string.IsNullOrEmpty(MSBuildPath) && File.Exists(MSBuildPath))
        {
            Logger.Log($"Using saved MSBuild path: {MSBuildPath}");
            return MSBuildPath;
        }

        // Try to find MSBuild.exe in PATH
        string msbuildInPath = FindMSBuildInPath();
        if (!string.IsNullOrEmpty(msbuildInPath))
        {
            MSBuildPath = msbuildInPath;
            SaveSettings();
            return msbuildInPath;
        }

        // Ask user to locate MSBuild.exe
        MessageBox.Show("Could not find MSBuild.exe. Please select the correct MSBuild.exe file.",
            "MSBuild Not Found",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);

        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Title = "Select MSBuild.exe",
            Filter = "MSBuild.exe|MSBuild.exe",
            InitialDirectory = @"C:\Program Files\"
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            MSBuildPath = openFileDialog.FileName;
            SaveSettings();
            return openFileDialog.FileName;
        }

        throw new FileNotFoundException("MSBuild.exe could not be located.");
    }

    private string FindMSBuildInPath()
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
        catch (Exception ex)
        {
            Logger.LogError($"MSBuild not found: {ex.Message}");
        }

        return null;
    }
    #endregion

    #region TortoiseGit
    public bool IsTortoiseGitAvailable => !string.IsNullOrEmpty(TortoiseGitPath) && File.Exists(TortoiseGitPath);

    public string TortoiseGitPath
    {
        get
        {
            if (string.IsNullOrEmpty(tortoiseGitPath) || !File.Exists(tortoiseGitPath))
            {
                tortoiseGitPath = FindTortoiseGitPath();
                SaveSettings();
            }
            return tortoiseGitPath;
        }
        set
        {
            tortoiseGitPath = value;
            SaveSettings();
        }
    }

    private static string FindTortoiseGitPath()
    {
        // Try to find TortoiseGitProc.exe in default installation paths
        List<string> potentialPaths = new List<string>
        {
            @"C:\Program Files\TortoiseGit\bin\TortoiseGitProc.exe",
            @"C:\Program Files (x86)\TortoiseGit\bin\TortoiseGitProc.exe"
        };

        foreach (string path in potentialPaths)
        {
            if (File.Exists(path))
            {
                Logger.Log($"TortoiseGit found at: {path}");
                return path;
            }
        }

        // Ask user to locate TortoiseGitProc.exe
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Title = "Select TortoiseGitProc.exe",
            Filter = "TortoiseGitProc.exe|TortoiseGitProc.exe",
            InitialDirectory = @"C:\Program Files\"
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
        {
            return openFileDialog.FileName;
        }

        return null;
    }
    #endregion
}
