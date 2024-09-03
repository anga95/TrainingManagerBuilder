using Newtonsoft.Json;
using JsonFormatting = Newtonsoft.Json.Formatting;

public class UserSettings
{
    public bool OpenTortoiseGitAfterBuild { get; set; }
    public bool OpenOutputDirectoryAfterBuild { get; set; }

    public static string ConfigFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userSettings.json");

    public static UserSettings LoadSettings()
    {
        if (File.Exists(ConfigFilePath))
        {
            string json = File.ReadAllText(ConfigFilePath);
            return JsonConvert.DeserializeObject<UserSettings>(json);
        }
        else
        {
            return new UserSettings();
        }
    }

    public void SaveSettings()
    {
        string json = JsonConvert.SerializeObject(this, JsonFormatting.Indented);
        File.WriteAllText(ConfigFilePath, json);
    }
}