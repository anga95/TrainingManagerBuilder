using System.Diagnostics;
using System.IO.Compression;

namespace TrainingManagerBuilder;

public class ZipUtilities
{
    Stopwatch stopwatch;
    public void ZipDirectory(string sourceDirectory, string zipFilePath)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Logger.LogNewSection($"Starting zipping of {sourceDirectory}");

        if (File.Exists(zipFilePath))
        {
            File.Delete(zipFilePath); // Deletes old zip file if it exists
        }

        ZipFile.CreateFromDirectory(sourceDirectory, zipFilePath);
        stopwatch.Stop();
        Logger.Log($"Zipping of {sourceDirectory} completed in {stopwatch.Elapsed.TotalSeconds} seconds.");
    }

    public void ReplaceZipFile(string installerPath, string newZipFilePath, string oldVersion, string newVersion, string program)
    {
        // Ersätt {version} i filnamnsmönstret med de faktiska versionsnumren
        string oldFileName = program + " " + oldVersion + ".zip";
        string oldFilePath = Path.Combine(installerPath, "Files", oldFileName);

        string newFileName = program + " " + newVersion + ".zip";
        string newFilePath = Path.Combine(installerPath, "Files", newFileName);

        // Ta bort den gamla filen om den finns
        if (File.Exists(oldFilePath))
        {
            File.Delete(oldFilePath);
            Console.WriteLine($"Deleted old file: {oldFilePath}");
        }

        // Ta bort den nya filen om den redan finns
        if (File.Exists(newFilePath))
        {
            File.Delete(newFilePath);
            Console.WriteLine($"Deleted existing new file: {newFilePath}");
        }

        // Kopiera den nya zip-filen till installer-mappen
        File.Copy(newZipFilePath, newFilePath);
        Console.WriteLine($"Copied new file: {newZipFilePath} to {newFilePath}");
    }

}