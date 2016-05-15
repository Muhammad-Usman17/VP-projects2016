using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void button_Click(object sender, RoutedEventArgs e)
        {

            string admin = textBox.Text.ToString();
            string password = passwordBox.Password.ToString();
            if (admin.Equals(ConfigUpdate.File.GetSetting("Admin")) && password.Equals(ConfigUpdate.File.GetSetting("Password")))
            {


                Window1 W = new Window1();
                W.Show();
                this.Hide();
                this.Close();
            }
            else
                MessageBox.Show("admin or passsword is wrong!!");
            passwordBox.Clear();

        }
      

     

    }
}
