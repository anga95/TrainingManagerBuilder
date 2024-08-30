using System.Collections.Concurrent;

public static class Logger
{
    private static readonly BlockingCollection<string> logQueue = new BlockingCollection<string>();
    private static string logFilePath;
    private static Task logTask;

    static Logger()
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        string fileName = $"log_{date}.txt";
        logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

        // Skapa katalogen om den inte finns
        string logDirectory = Path.GetDirectoryName(logFilePath);
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }

        // Starta bakgrundstråden för att hantera loggningen
        logTask = Task.Factory.StartNew(ProcessLogQueue, TaskCreationOptions.LongRunning);

        // Skapa eller rensa loggfilen när programmet startar
        using (StreamWriter sw = File.CreateText(logFilePath))
        {
            sw.WriteLine("Log started: " + DateTime.Now.ToString());
        }
    }

    public static void Log(string message)
    {
        logQueue.Add($"{DateTime.Now.ToString()}: {message}");
    }
    public static void LogNewSection(string message)
    {
        logQueue.Add($"{Environment.NewLine}{DateTime.Now.ToString()}: {message}");
    }

    public static void LogError(string message)
    {
        logQueue.Add($"{DateTime.Now.ToString()}: ERROR: {message}");
    }

    private static void ProcessLogQueue()
    {
        foreach (var logEntry in logQueue.GetConsumingEnumerable())
        {
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine(logEntry);
            }
        }
    }

    public static void Dispose()
    {
        logQueue.CompleteAdding();
        logTask.Wait();
    }
}
