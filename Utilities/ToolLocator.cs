using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public static class ToolLocator
{
    public static string FindTool(string toolName, List<string> potentialPaths)
    {
        foreach (string path in potentialPaths)
        {
            if (File.Exists(path))
            {
                Logger.Log($"{toolName} found at: {path}");
                return path;
            }
        }

        // Ask user to locate the tool
        MessageBox.Show($"Could not find {toolName}. Please select the correct {toolName} file.",
            $"{toolName} Not Found",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);

        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Title = $"Select {toolName}",
            Filter = $"{toolName}|{toolName}",
            InitialDirectory = @"C:\Program Files\"
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
        {
            Logger.Log($"{toolName} selected by user at: {openFileDialog.FileName}");
            return openFileDialog.FileName;
        }

        return null;
    }

    public static string FindMSBuildPath()
    {
        List<string> potentialPaths = new List<string>
        {
            // Visual Studio 2017 Build Tools
            @"C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin\MSBuild.exe",

            // Visual Studio 2017 Enterprise
            @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\MSBuild.exe",

            // Visual Studio 2017 Professional
            @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\MSBuild.exe",

            // Visual Studio 2017 Community
            @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe"
        };

        return FindTool("MSBuild.exe", potentialPaths);
    }

    public static string FindTortoiseGitPath()
    {
        List<string> potentialPaths = new List<string>
        {
            @"C:\Program Files\TortoiseGit\bin\TortoiseGitProc.exe",
            @"C:\Program Files (x86)\TortoiseGit\bin\TortoiseGitProc.exe"
        };

        return FindTool("TortoiseGitProc.exe", potentialPaths);
    }
}
