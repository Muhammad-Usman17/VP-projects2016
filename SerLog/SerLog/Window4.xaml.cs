
using System.Windows;


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

            textBox1.Text = ConfigUpdate.File.GetSetting("SystemMail");
            textBox3.Text = ConfigUpdate.File.GetSetting("AdminEMail");
            textBox4.Text = ConfigUpdate.File.GetSetting("subject");
            textBox5.Text = ConfigUpdate.File.GetSetting("body");
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (SendMail.mail.emailIsValid(textBox1.Text) && SendMail.mail.emailIsValid(textBox3.Text))
            {
                ConfigUpdate.File.SetSetting("SystemMail", textBox1.Text);

                ConfigUpdate.File.SetSetting("AdminEMail", textBox3.Text);
                ConfigUpdate.File.SetSetting("subject", textBox4.Text);
                ConfigUpdate.File.SetSetting("body", textBox5.Text);
                MessageBox.Show("Sucessfully Saved");
            }
            else
            {
                if (!SendMail.mail.emailIsValid(textBox1.Text) && !SendMail.mail.emailIsValid(textBox3.Text))
                {
                    textBox1.Focus();
                    MessageBox.Show("you entered Invalid SystemMail Address and AdminEMail");

                }
                else if (!SendMail.mail.emailIsValid(textBox1.Text))
                {
                    textBox1.Focus();
                    MessageBox.Show("you entered Invalid SystemMail Address ");
                }

                else if (!SendMail.mail.emailIsValid(textBox3.Text))
                {
                    textBox3.Focus();

                    MessageBox.Show("you entered Invalid AdminEMail Address ");
                }

            }
        }


        private void test(object sender, RoutedEventArgs e)
        {
            SendMail.mail.sendNotification(ConfigUpdate.File.GetSetting("SystemMail"), ConfigUpdate.File.GetSetting("AdminEMail"));
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
