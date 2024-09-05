using System;
using System.Windows.Forms;

namespace TrainingManagerBuilder
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            try
            {
                Logger.Log("Application started");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                Logger.Log("Application ended");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }

        }
    }
}