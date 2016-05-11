using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show( "Service Path is empty" );
               
            }
            else
            {
                try {

                    InstallService(textBox.Text);
                }
                catch(Exception t)
                {
                    MessageBox.Show(t.Message);
                }
            }
           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 W1 = new Window1();
            W1.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();


            dlg.DefaultExt = ".exe";
            dlg.Filter = "Service Exe Files (*.exe)|*.exe";


           
            Nullable<bool> result = dlg.ShowDialog();


           
            if (result == true)
            {
                
                string filename = dlg.FileName;
                textBox.Text=filename;
            }
        }
        public void InstallService(string pathToAssembly)
        {
            System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] { pathToAssembly });
            MessageBox.Show("DONE");
        }
    }
}
