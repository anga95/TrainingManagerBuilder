using System.Diagnostics;

public class TortoiseGitHelper
{
    private readonly string tortoiseGitPath;

    public TortoiseGitHelper(string tortoiseGitExecutablePath = @"C:\Program Files\TortoiseGit\bin\TortoiseGitProc.exe")
    {
        if (File.Exists(tortoiseGitExecutablePath))
        {
            tortoiseGitPath = tortoiseGitExecutablePath;
        }
        else
        {
            throw new FileNotFoundException("TortoiseGit executable not found at the specified path.");
        }
    }

    public void OpenCommitDialog(string repositoryPath, string newVersion)
    {
        try
        {
            AddFilestogit(repositoryPath, newVersion);

            string commitMessage = $"Release {newVersion}";

            // Open TortoiseGit commit dialog
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = tortoiseGitPath,
                Arguments = $"/command:commit /path:\"{repositoryPath}\" /logmsg:\"{commitMessage}\"",
                UseShellExecute = true
            };

            Process.Start(startInfo);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to open TortoiseGit: {ex.Message}");
            throw; // Optionally rethrow or handle the exception as needed
        }
    }

    private void AddFilestogit(string repositoryPath, string newVersion)
    {
        List<string> filesToAdd = new List<string>
        {
            Path.Combine(repositoryPath, $"TMInstaller\\Files\\TM {newVersion}.zip"),
            Path.Combine(repositoryPath, $"TMInstaller\\Files\\TM Reports Website {newVersion}.zip")
        };

        // Se till att alla nya filer är versionerade
        foreach (var file in filesToAdd)
        {
            ProcessStartInfo gitAddInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = $"add \"{file}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = repositoryPath
            };

            using (Process process = Process.Start(gitAddInfo))
            {
                process.WaitForExit();
                if (process.ExitCode != 0)
                {
                    string error = process.StandardError.ReadToEnd();
                    Logger.LogError($"Failed to add file {file} to git: {error}");
                }
            }
        }
    }
}