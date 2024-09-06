using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using JsonFormatting = Newtonsoft.Json.Formatting;

public class UserSettings
{
    public bool OpenOutputDirectoryAfterBuild { get; set; }
    public bool OpenTortoiseGitAfterBuild { get; set; }

    public bool RememberSourcePath { get; set; }
    [JsonProperty]
    private string sourcePath;
    public string SourcePath
    {
        get => !string.IsNullOrEmpty(sourcePath) && Directory.Exists(sourcePath) ? sourcePath : null;
        set
        {
            sourcePath = RememberSourcePath ? value : null;
            SaveSettings();
        }
    }

    public bool RememberOutputPath { get; set; }
    [JsonProperty]
    private string outputPath;
    public string OutputPath
    {
        get => !string.IsNullOrEmpty(outputPath) && Directory.Exists(outputPath) ? outputPath : null;
        set
        {
            outputPath = RememberOutputPath ? value : null;
            SaveSettings();
        }
    }


    private string msbuildPath;
    private string tortoiseGitPath;


    private UserSettings() { }

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
            var loadedSettings = JsonConvert.DeserializeObject<UserSettings>(json);

            // Kontrollera att de privata fälten sätts korrekt vid uppstart
            loadedSettings.sourcePath = loadedSettings.RememberSourcePath ? loadedSettings.sourcePath : null;
            loadedSettings.outputPath = loadedSettings.RememberOutputPath ? loadedSettings.outputPath : null;

            return loadedSettings;
        }

        return new UserSettings();  // Return default settings if file does not exist
    }

    public void SaveSettings()
    {
        //if (!RememberSourcePath)
        //{
        //    SourcePath = null;
        //}
        //if (!RememberOutputPath)
        //{
        //    OutputPath = null;
        //}
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
        if (!string.IsNullOrEmpty(msbuildPath) && File.Exists(msbuildPath))
        {
            Logger.Log($"Using saved MSBuild path: {msbuildPath}");
            return msbuildPath;
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
                msbuildPath = path;
                SaveSettings();
                return path;
            }
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
            msbuildPath = openFileDialog.FileName;
            SaveSettings();
            return openFileDialog.FileName;
        }

        throw new FileNotFoundException("MSBuild.exe could not be located.");
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
