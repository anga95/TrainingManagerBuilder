using System.Text;
using System.Text.RegularExpressions;

public class VersionManager
{
    private string versionPattern = @"\d+\.\d+\.\d+\.\d+";
    private List<string> filesToUpdate;

    public VersionManager(string sourcePath)
    {
        filesToUpdate = new List<string>
        {
            Path.Combine(sourcePath, @"BusinessLayer\Properties\AssemblyInfo.cs"),
            Path.Combine(sourcePath, @"TM\Properties\AssemblyInfo.cs"),
            Path.Combine(sourcePath, @"TM\TranslationKeys.xml"),
            Path.Combine(sourcePath, @"TMInstaller\Files\Settings.xml"),
            Path.Combine(sourcePath, @"TMInstaller\Properties\AssemblyInfo.cs"),
            Path.Combine(sourcePath, @"TMInstaller\TranslationKeys.xml"),
            Path.Combine(sourcePath, @"TMReportsWebsite\Version\Version.txt"),
            Path.Combine(sourcePath, @"TMService\Properties\AssemblyInfo.cs"),
            Path.Combine(sourcePath, @"TranslationFileConverter\Properties\AssemblyInfo.cs"),
            Path.Combine(sourcePath, @"UserInterface\Properties\AssemblyInfo.cs")
        };
    }

    public (int Major, int Minor, int Build, int Revision) GetCurrentVersion()
    {
        string content = File.ReadAllText(filesToUpdate[0]);
        Match match = Regex.Match(content, versionPattern);
        if (match.Success)
        {
            string version = match.Value;
            var versionParts = version.Split('.');
            int major = int.Parse(versionParts[0]);
            int minor = int.Parse(versionParts[1]);
            int build = int.Parse(versionParts[2]);
            int revision = int.Parse(versionParts[3]);
            return (major, minor, build, revision);
        }
        throw new InvalidOperationException("Version number not found in the specified files.");
    }

    public void UpdateVersionInFiles(string newVersion)
    {
        Logger.LogNewSection($"Starting version update to {newVersion}");
        var logBuilder = new StringBuilder();
        var updateCount = 0;
        foreach (var file in filesToUpdate)
        {
            string content = File.ReadAllText(file);

            int originalMatches = Regex.Matches(content, versionPattern).Count;

            content = Regex.Replace(content, versionPattern, newVersion);

            int newMatches = Regex.Matches(content, newVersion).Count;

            int updatedMatches = originalMatches;

            File.WriteAllText(file, content);

            logBuilder.AppendLine($"Updated {file}: {updatedMatches} occurrences replaced.");
        }

        int totalChanges = filesToUpdate.Sum(file =>
        {
            string content = File.ReadAllText(file);
            return Regex.Matches(content, newVersion).Count;
        });

        logBuilder.AppendLine($"Total changes: {totalChanges}");
        Logger.Log(logBuilder.ToString());
    }

    public (int Major, int Minor, int Build, int Revision) GetNextVersion(int currentMajor, int currentMinor, int currentBuild, int currentRevision)
    {
        int nextRevision = currentRevision + 1;
        return (currentMajor, currentMinor, currentBuild, nextRevision);
    }
}
