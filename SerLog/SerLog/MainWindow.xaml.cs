using System;
using System.Windows;


namespace SerLog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += new EventHandler(Timer_click);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            textBox.Focus();
                
            
        }
        private void Timer_click(object sender, EventArgs e)
        {
            label3.Content = DateTime.Now.ToString("HH:mm:ss") + " " + DateTime.Now.ToLongDateString();
        }

        private void Login(object sender, RoutedEventArgs e)
        {

            //string admin = textBox.Text.ToString();
            //string password = passwordBox.Password.ToString();
            //if (admin.Equals(ConfigUpdate.File.GetSetting("Admin")) && password.Equals(ConfigUpdate.File.GetSetting("Password")))
            //{


                Window1 W = new Window1();
                W.Show();
                this.Hide();
                this.Close();
            //}
            //else
            //    MessageBox.Show("admin or passsword is wrong!!");
            //passwordBox.Clear();

        }

        private void lostpassword(object sender, RoutedEventArgs e)
        {
            string Password = "Your Password is  " + ConfigUpdate.File.GetSetting("Password");
            SendMail.mail.sendNotification(Password, ConfigUpdate.File.GetSetting("SystemMail"), ConfigUpdate.File.GetSetting("AdminEMail"));
            MessageBox.Show("Password details are sent to your Email address");
        }
    }
}
