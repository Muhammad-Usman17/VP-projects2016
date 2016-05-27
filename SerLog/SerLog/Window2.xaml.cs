using System.Windows;
using System.Windows.Controls;


namespace SerLog
{
    /// <summary>
    /// this class is to change the configuration of mailserver and also to application authentication setting (password)...
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            textBox1.Text = ConfigUpdate.File.GetSetting("Admin");
            textBox2.Text = ConfigUpdate.File.GetSetting("Password");
            textBox3.Text = ConfigUpdate.File.GetSetting("mailhost");
            textBox4.Text = ConfigUpdate.File.GetSetting("port");
            textBox.Text = ConfigUpdate.File.GetSetting("Systempassword");

        }


        private void homecreen(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 W = new Window1();
            W.Show();
            this.Close();
        }



        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers input like (8080,587)etc.");
                textBox4.Clear();
            }
        }


        private void updatesetting(object sender, RoutedEventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox.Text != "")
            {
                ConfigUpdate.File.SetSetting("Admin", textBox1.Text.ToString());
                ConfigUpdate.File.SetSetting("Password", textBox2.Text.ToString());
                ConfigUpdate.File.SetSetting("mailhost", textBox3.Text.ToString());
                ConfigUpdate.File.SetSetting("port", textBox4.Text.ToString());
                ConfigUpdate.File.SetSetting("Systempassword", textBox.Text.ToString());
                MessageBox.Show("Sucessfully Saved");
            }
            else
                MessageBox.Show("Error!!one or more field is empty");

        }


    }

}
