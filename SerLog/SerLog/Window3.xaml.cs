using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace SerLog
{
    /// <summary>
    /// this class is to read logfile,print logfile and clear the log file....
    /// </summary>
    public partial class Window3 : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public Window3()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Timer_click);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();


        }
        private void Timer_click(object sender, EventArgs e)
        {
            textBox.Text = Log.func.readlastError();
        }

        private void openlogfile(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(ConfigUpdate.File.GetSetting("LogFilePath"));
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void printlog(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.func.PrintFile(ConfigUpdate.File.GetSetting("LogFilePath"));
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void deletelog(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to Clear the logfile?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    File.WriteAllText(ConfigUpdate.File.GetSetting("LogFilePath"), String.Empty);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }

        }

        private void homescreen(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 W = new Window1();
            W.Show();
            this.Close();
        }
    }
}
