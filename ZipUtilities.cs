using System.IO.Compression;

namespace TrainingManagerBuilder;

public class ZipUtilities
{
    public void ZipDirectory(string sourceDirectory, string zipFilePath)
    {
        if (File.Exists(zipFilePath))
        {
            File.Delete(zipFilePath); // Deletes old zip file if it exists
        }

        ZipFile.CreateFromDirectory(sourceDirectory, zipFilePath);
        Console.WriteLine($"Zipped {sourceDirectory} to {zipFilePath}");
    }

    public void ReplaceZipFile(string installerPath, string newZipFilePath, string oldVersion, string newVersion, string targetFileNamePattern)
    {
        string oldFileName = targetFileNamePattern.Replace("{version}", oldVersion);
        string oldFilePath = Path.Combine(installerPath, "Files", oldFileName);

        string newFileName = targetFileNamePattern.Replace("{version}", newVersion);
        string newFilePath = Path.Combine(installerPath, "Files", newFileName);

        if (File.Exists(oldFilePath))
        {
            File.Delete(oldFilePath);
            Console.WriteLine($"Deleted old file: {oldFilePath}");
        }

        File.Copy(newZipFilePath, newFilePath);
        Console.WriteLine($"Copied new file: {newZipFilePath} to {newFilePath}");
    }
}