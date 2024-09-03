using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

public class ProcessTimerManager
{
    private Dictionary<ProgressBar, (Stopwatch, Timer, Label)> processTimers;

    public ProcessTimerManager(Dictionary<ProgressBar, Label> progressBarLabels)
    {
        processTimers = progressBarLabels.ToDictionary(
            kvp => kvp.Key,
            kvp => (new Stopwatch(), new Timer { Interval = 1000 }, kvp.Value)
        );

        foreach (var entry in processTimers)
        {
            entry.Value.Item2.Tick += (sender, e) =>
            {
                entry.Value.Item3.Text = entry.Value.Item1.Elapsed.ToString(@"hh\:mm\:ss");
            };
        }
    }

    public void StartTimer(ProgressBar progressBar)
    {
        var (stopwatch, timer, label) = processTimers[progressBar];
        label.Text = "00:00:00";
        stopwatch.Reset();
        stopwatch.Start();
        timer.Start();
    }

    public void StopTimer(ProgressBar progressBar)
    {
        var (stopwatch, timer, label) = processTimers[progressBar];
        stopwatch.Stop();
        timer.Stop();
        label.Text += " - Done";
    }
}