using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ProgressBar = System.Windows.Forms.ProgressBar;
using Timer = System.Windows.Forms.Timer;

public class ProgressStepManager : IDisposable
{
    private ProgressBar progressBar { get; }

    public ProgressBar ProgressBar
    {
        get { return progressBar; }
    }
    private Label timerLabel { get; }
    private Label statusLabel { get; }
    private Label stepLabel { get; }
    private Stopwatch stopwatch { get; }
    private Timer timer { get; }

    public ProgressStepManager(Label stepLabel, ProgressBar progressBar, Label timerLabel, Label statusLabel)
    {
        this.stepLabel = stepLabel;
        this.progressBar = progressBar;
        this.timerLabel = timerLabel;
        this.statusLabel = statusLabel;

        stopwatch = new Stopwatch();
        timer = new Timer { Interval = 1000 }; // Update every second

        // Attach the event to update the elapsed time label
        timer.Tick += (sender, e) =>
        {
            this.timerLabel.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
        };
    }

    public void Start(int? maximum = null)
    {
        // Timers
        timerLabel.Text = "00:00:00";
        stopwatch.Reset();
        stopwatch.Start();
        timer.Start();

        //Progressbar
        progressBar.Value = 0;
        if (maximum != null)
        {
            setProgressBarMaximum(maximum.Value);
        }

        UpdateStatus("In progress...");
    }

    public void Stop()
    {
        stopwatch.Stop();
        timer.Stop();

        UpdateStatus("Completed");
    }

    public void Failed()
    {
        stopwatch.Stop();
        timer.Stop();

        SetProgressBarColor(Color.Red);
        UpdateStatus("Failed");
    }

    public void SetProgress(int value)
    {
        if (progressBar.InvokeRequired)
        {
            progressBar.Invoke(new Action(() => progressBar.Value = value));
        }
        else
        {
            progressBar.Value = value;
        }
    }

    public void UpdateStatus(string status)
    {
        if (statusLabel.InvokeRequired)
        {
            statusLabel.Invoke(new Action(() => statusLabel.Text = status));
        }
        else
        {
            statusLabel.Text = status;
        }
    }

    private void setProgressBarMaximum(int maximum)
    {
        if (progressBar.InvokeRequired)
        {
            progressBar.Invoke(new Action(() => progressBar.Maximum = maximum));
        }
        else
        {
            progressBar.Maximum = maximum;
        }
    }

    private void SetProgressBarColor(Color color)
    {
        if (progressBar.InvokeRequired)
        {
            progressBar.Invoke(new Action(() => progressBar.ForeColor = color));
        }
        else
        {
            progressBar.ForeColor = color;
        }
    }

    public void SetWaiting()
    {
        timerLabel.Text = "Waiting...";
    }

    public void ResetProgressBar()
    {
        progressBar.Value = 0;
    }

    public void Dispose()
    {
        timer?.Dispose();
        stopwatch?.Stop();
    }
}
