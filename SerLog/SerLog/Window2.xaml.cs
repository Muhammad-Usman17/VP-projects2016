using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
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
using System.Xml;

namespace SerLog
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 W = new Window1();
            
           W.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
          
            

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string newmail = textBox.Text.ToString();
            if (!SendMail.mail.IsValidEmail(newmail))
            {
                MessageBox.Show("You enter the invalid email!!");
            }
            else
            {
                ConfigUpdate.File.SetSetting("AdminEMail", newmail);
                MessageBox.Show("Admin name is Sucesfully changed");
            }
        }
       


        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            SendMail.mail.sendNotification(ConfigUpdate.File.GetSetting("SystemMail"), ConfigUpdate.File.GetSetting("AdminEMail"));
         

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string newADMIN = textBox1.Text.ToString();
            ConfigUpdate.File.SetSetting("Admin", newADMIN);
            MessageBox.Show("Admin name is Sucesfully changed");
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            string newpaswword = textBox2.Text.ToString();
            ConfigUpdate.File.SetSetting("Password", newpaswword);
            MessageBox.Show("Admin Password is Sucesfully changed");
        }

        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }
    }
    
}
