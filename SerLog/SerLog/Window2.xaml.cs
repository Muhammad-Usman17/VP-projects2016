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
            if (!IsValidEmail(newmail))
            {
                MessageBox.Show("You enter the invalid email!!");
            }
            else
            {
                SetSetting("AdminEMail", newmail);
                MessageBox.Show("Admin name is Sucesfully changed");
            }
        }
        private static string GetSetting(string key)
        {
            ConfigurationManager.RefreshSection("appSettings");
            return ConfigurationManager.AppSettings[key];
        }

        private static void SetSetting(string key, string value)
        {
        
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified, true);
            config.SaveAs(@"C:\Users\Muhammad_Usman\Documents\Visual Studio 2015\Projects\VP-projects2016\SerLog\SerLog\App.config", ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");


        }
        private static void sendNotificarion(String appAdd,String adminAdd)
        {

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(appAdd, "bse123456");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(appAdd);
            mail.To.Add(adminAdd);
            mail.Subject = "Email testing";
            mail.Body = "serlog verification test";
            try
            {
                client.Send(mail);
               MessageBox.Show("Email sent ");
            }
            catch (SmtpException e)
            {
               
                MessageBox.Show(e.InnerException.Message);
            }
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            sendNotificarion(GetSetting("SystemMail"), GetSetting("AdminEMail"));
            

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string newADMIN = textBox1.Text.ToString();
            SetSetting("Admin", newADMIN);
            MessageBox.Show("Admin name is Sucesfully changed");
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            string newpaswword = textBox2.Text.ToString();
            SetSetting("Password", newpaswword);
            MessageBox.Show("Admin Password is Sucesfully changed");
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
