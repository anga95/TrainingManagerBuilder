using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;

public class UserSettings
{
    // Singleton implementation
    private static readonly Lazy<UserSettings> lazyInstance = new Lazy<UserSettings>(() => LoadSettings(), LazyThreadSafetyMode.ExecutionAndPublication);
    public static UserSettings Instance => lazyInstance.Value;

    private UserSettings()
    {
        OpenOutputDirectoryAfterBuild = false;
        OpenTortoiseGitAfterBuild = false;
        RememberOutputPath = false;
        RememberSourcePath = false;
        SourcePath = string.Empty;
        OutputPath = string.Empty;
        MSBuildPath = string.Empty;
        TortoiseGitPath = string.Empty;
    }

    [JsonProperty]
    public bool OpenOutputDirectoryAfterBuild
    {
        get => _openOutputDirectoryAfterBuild;
        set
        {
            if (_openOutputDirectoryAfterBuild != value)
            {
                _openOutputDirectoryAfterBuild = value;
                Logger.Log($"OpenOutputDirectoryAfterBuild set to {value}");
                SaveSettings();
            }
        }
    }
    private bool _openOutputDirectoryAfterBuild;

    [JsonProperty]
    public bool OpenTortoiseGitAfterBuild
    {
        get => _openTortoiseGitAfterBuild;
        set
        {
            if (_openTortoiseGitAfterBuild != value)
            {
                _openTortoiseGitAfterBuild = value;
                Logger.Log($"OpenTortoiseGitAfterBuild set to {value}");
                SaveSettings();
            }
        }
    }
    private bool _openTortoiseGitAfterBuild;

    [JsonProperty]
    public bool RememberOutputPath
    {
        get => _rememberOutputPath;
        set
        {
            if (_rememberOutputPath != value)
            {
                _rememberOutputPath = value;
                Logger.Log($"RememberOutputPath set to {value}");
                if (!value)
                {
                    OutputPath = null;
                }
                SaveSettings();
            }
        }
    }
    private bool _rememberOutputPath;

    [JsonProperty]
    public bool RememberSourcePath
    {
        get => _rememberSourcePath;
        set
        {
            if (_rememberSourcePath != value)
            {
                _rememberSourcePath = value;
                Logger.Log($"RememberSourcePath set to {value}");
                if (!value)
                {
                    SourcePath = null;
                }
                SaveSettings();
            }
        }
    }
    private bool _rememberSourcePath;

    [JsonProperty]
    public string SourcePath
    {
        get => IsValidPath(_sourcePath) ? _sourcePath : null;
        set
        {
            if (_sourcePath != value)
            {
                _sourcePath = RememberSourcePath ? value : null;
                Logger.Log($"SourcePath set to {_sourcePath}");
                SaveSettings();
            }
        }
    }
    private string _sourcePath;

    [JsonProperty]
    public string OutputPath
    {
        get => IsValidPath(_outputPath) ? _outputPath : null;
        set
        {
            if (_outputPath != value)
            {
                _outputPath = RememberOutputPath ? value : null;
                Logger.Log($"OutputPath set to {_outputPath}");
                SaveSettings();
            }
        }
    }
    private string _outputPath;

    [JsonProperty]
    public string MSBuildPath
    {
        get
        {
            if (IsValidFilePath(_msbuildPath))
            {
                return _msbuildPath;
            }

            _msbuildPath = ToolLocator.FindMSBuildPath();
            if (!string.IsNullOrEmpty(_msbuildPath))
            {
                Logger.Log($"MSBuildPath found: {_msbuildPath}");
                SaveSettings();
            }
            return _msbuildPath;
        }
        set
        {
            if (_msbuildPath != value)
            {
                _msbuildPath = value;
                Logger.Log($"MSBuildPath set to {_msbuildPath}");
                SaveSettings();
            }
        }
    }
    private string _msbuildPath;

    [JsonProperty]
    public string TortoiseGitPath
    {
        get
        {
            if (IsValidFilePath(_tortoiseGitPath))
            {
                return _tortoiseGitPath;
            }

            _tortoiseGitPath = ToolLocator.FindTortoiseGitPath();
            if (!string.IsNullOrEmpty(_tortoiseGitPath))
            {
                Logger.Log($"TortoiseGitPath found: {_tortoiseGitPath}");
                SaveSettings();
            }
            return _tortoiseGitPath;
        }
        set
        {
            if (_tortoiseGitPath != value)
            {
                _tortoiseGitPath = value;
                Logger.Log($"TortoiseGitPath set to {_tortoiseGitPath}");
                SaveSettings();
            }
        }
    }
    private string _tortoiseGitPath;

    public bool IsTortoiseGitAvailable => !string.IsNullOrEmpty(TortoiseGitPath) && File.Exists(TortoiseGitPath);

    #region Settings Loading/Saving
    public static string ConfigFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userSettings.json");
    private static readonly object fileLock = new object();

    private static UserSettings LoadSettings()
    {
        try
        {
            if (File.Exists(ConfigFilePath))
            {
                string json = File.ReadAllText(ConfigFilePath);
                var loadedSettings = JsonConvert.DeserializeObject<UserSettings>(json);

                return loadedSettings ?? new UserSettings();
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to load settings from {ConfigFilePath}. Exception: {ex.Message}");
        }

        return new UserSettings();
    }

    public void SaveSettings()
    {
        lock (fileLock)
        {
            try
            {
                // Säkerställ att mappen finns
                string directory = Path.GetDirectoryName(ConfigFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                Logger.Log($"Saving settings: {json}"); // Log the JSON string
                File.WriteAllText(ConfigFilePath, json);
                Logger.Log($"Settings saved to {ConfigFilePath}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failed to save settings to {ConfigFilePath}. Exception: {ex.Message}");
            }
        }
    }
    #endregion

    #region Helper Methods
    private bool IsValidPath(string path)
    {
        return !string.IsNullOrEmpty(path) && Directory.Exists(path);
    }

    private bool IsValidFilePath(string path)
    {
        return !string.IsNullOrEmpty(path) && File.Exists(path);
    }
    #endregion
}
