using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
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
        List<string> allservices;
        public Window5()
        {
            InitializeComponent();
            allservices = new List<string>();
            System.ServiceProcess.ServiceController[] services;
            services = System.ServiceProcess.ServiceController.GetServices();
            allservices.Clear();
            for (int i = 0; i < services.Length; i++)
            {
                if(services[i].ServiceName=="ServiceMoniter")
                {

                }
                else
                allservices.Add(services[i].ServiceName);
            }
            listBox.Visibility = Visibility.Collapsed;

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
            //System.Configuration.Install.ManagedInstallerClass
            //                .InstallHelper(new string[] { "/u", pathToAssembly });
            MessageBox.Show("Installed Sucessfully...");
           
        }
        public void Uninstall(String Sname)
        {
          
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            String typed = textBox1.Text;
            List<String> auto = new List<string>();
            auto.Clear();
            foreach(String item in allservices)
            {
                if(!String.IsNullOrEmpty(textBox1.Text))
                {
                    if(item.StartsWith(typed))
                    {
                        auto.Add(item);
                    }
                }
               
            }
            if (auto.Count > 0)
            {
                listBox.ItemsSource = auto;
                listBox.Visibility = Visibility.Visible;
            }
            else if (textBox1.Text.Equals(""))
            {
                
                listBox.Visibility = Visibility.Collapsed;
                listBox.ItemsSource =null;
            }
            else
            {
                listBox.Visibility = Visibility.Collapsed;
                listBox.ItemsSource = null;

            }




        }
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listBox.ItemsSource !=null)
            {
                listBox.Visibility = Visibility.Collapsed;
                textBox1.TextChanged -= new TextChangedEventHandler(textBox1_TextChanged);
                if(listBox.SelectedIndex!=-1)
                {
                    textBox1.Text = listBox.SelectedItem.ToString();
                }
                textBox1.TextChanged += new TextChangedEventHandler(textBox1_TextChanged);
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Boolean check= false;
            foreach (string itm in allservices)
            {
                if (textBox1.Text != itm)
                    check = false;
                else
                {
                    check = true;
                    break;
                }
            }

            if (check == true)
            {
                Log.func.writefilebat(textBox1.Text, ConfigUpdate.File.GetSetting("BatFilePath"));
                System.Diagnostics.Process Proc = new System.Diagnostics.Process();
                Proc.StartInfo.FileName = ConfigUpdate.File.GetSetting("BatFilePath");
                Proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                Proc.Start();
                MessageBox.Show("Uninstalled Sucessfully...");
            }
            else
                MessageBox.Show("ERR0R ! You entered invalid Service ...");



            }



        }

        
    }
