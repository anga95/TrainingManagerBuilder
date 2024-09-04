using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

public class ProgressStepManager
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

    public void Start(int maximum)
    {
        // Timers
        timerLabel.Text = "00:00:00";
        stopwatch.Reset();
        stopwatch.Start();
        timer.Start();

        //Progressbar
        progressBar.Value = 0;
        progressBar.Maximum = maximum;

        statusLabel.Text = "In progress...";
    }
    public void Start()
    {
        // Timers
        timerLabel.Text = "00:00:00";
        stopwatch.Reset();
        stopwatch.Start();
        timer.Start();

        //Progressbar
        progressBar.Value = 0;

        statusLabel.Text = "In progress...";
    }

    public void Stop()
    {
        stopwatch.Stop();
        timer.Stop();

        statusLabel.Text = "Completed";
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

    public void SetStepLabel(string text)
    {
        if (stepLabel.InvokeRequired)
        {
            stepLabel.Invoke(new Action(() => stepLabel.Text = text));
        }
        else
        {
            stepLabel.Text = text;
        }
    }

    public void SetStatus(string text)
    {
        if (statusLabel.InvokeRequired)
        {
            statusLabel.Invoke(new Action(() => statusLabel.Text = text));
        }
        else
        {
            statusLabel.Text = text;
        }
    }
    public void SetWaiting()
    {
        timerLabel.Text = "Waiting...";
        statusLabel.Text = "Waiting";
    }

    public void ResetProgressBar()
    {
        progressBar.Value = 0;
    }
}
