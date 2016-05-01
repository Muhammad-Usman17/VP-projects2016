using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SerLog
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            textBox.Text = ConfigUpdate.File.GetSetting("");
            textBox1.Text = ConfigUpdate.File.GetSetting("SystemMail");
            textBox2.Text = ConfigUpdate.File.GetSetting("");
            textBox3.Text = ConfigUpdate.File.GetSetting("AdminEMail");
            textBox4.Text = ConfigUpdate.File.GetSetting("subject");
            textBox5.Text = ConfigUpdate.File.GetSetting("body");


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
          
            ConfigUpdate.File.SetSetting("SystemMail",textBox1.Text);
       
            ConfigUpdate.File.SetSetting("AdminEMail",textBox3.Text);
            ConfigUpdate.File.SetSetting("subject",textBox4.Text);
            ConfigUpdate.File.SetSetting("body",textBox5.Text);
            MessageBox.Show("Sucessfully Saved");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 W = new Window1();
            W.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SendMail.mail.sendNotification(ConfigUpdate.File.GetSetting("SystemMail"), ConfigUpdate.File.GetSetting("AdminEMail"));
        }
    }
}
