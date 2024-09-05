using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public static class Logger
{
    private static readonly BlockingCollection<string> logQueue = new BlockingCollection<string>();
    private static string logFilePath;
    private static Task logTask;
    private static CancellationTokenSource cts = new CancellationTokenSource();

    static Logger()
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        string fileName = $"log_{date}.txt";
        logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", fileName);

        string logDirectory = Path.GetDirectoryName(logFilePath);
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }

        // Create a task to process the log queue
        logTask = Task.Factory.StartNew(() => ProcessLogQueue(cts.Token), cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

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
        logQueue.Add($"{Environment.NewLine}{DateTime.Now}: {message}");
    }

    public static void LogError(string message)
    {
        logQueue.Add($"{DateTime.Now}: ERROR: {message}");
    }

    public static void LogError(string message, Exception ex = null)
    {
        string errorMessage = $"{DateTime.Now}: ERROR: {message}";

        if (ex != null)
        {
            var stackTrace = new System.Diagnostics.StackTrace(ex, true);
            var frame = stackTrace.GetFrame(0);
            var fileName = frame.GetFileName();
            var lineNumber = frame.GetFileLineNumber();

            errorMessage += $"\nException: {ex.Message}\nStackTrace: {ex.StackTrace}\nLocation: {fileName} - Line: {lineNumber}";
        }

        logQueue.Add(errorMessage);
    }

    private static void ProcessLogQueue(CancellationToken token)
    {
        try
        {
            foreach (var logEntry in logQueue.GetConsumingEnumerable(token))
            {
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine(logEntry);
                }
            }
        }
        catch (OperationCanceledException ex)
        {
            Console.Error.WriteLine($"Logging was canceled: {ex.Message}");

        }
        catch (IOException ex)
        {
            // Logging canceled or I/O error occurred
            Console.Error.WriteLine($"Logging failed due to I/O error: {ex.Message}");
        }
    }

    public static void Dispose()
    {
        logQueue.CompleteAdding();
        cts.Cancel();
        try
        {
            logTask.Wait(cts.Token); // Wait for the log task to finish processing
        }
        catch (OperationCanceledException)
        {
            // Expected during shutdown, no need to handle
        }
        catch (AggregateException ae)
        {
            // Log or handle any exceptions thrown by the logging task
            ae.Handle(ex =>
            {
                Console.Error.WriteLine($"Error during logging disposal: {ex.Message}");
                return true;
            });
        }
    }
}
