﻿using System;
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

using System.ServiceProcess;
using System.Configuration;
using System.IO;

namespace SerLog
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ServiceController sc;
        public Window1()
        {
            InitializeComponent();
            sc = new System.ServiceProcess.ServiceController("ServiceMoniter");
            if (sc.Status.Equals(ServiceControllerStatus.Stopped))
            {
                button.IsEnabled = true;
                button3.IsEnabled = true;
                button8.IsEnabled = true;
                button2.IsEnabled = false;

            }
            else if (sc.Status.Equals(ServiceControllerStatus.Running))
            {
                button.IsEnabled = false;
                button3.IsEnabled = false;
                button8.IsEnabled = false;
                button2.IsEnabled = true;
                String[] ser = Log.func.readfile();
                for(int i=0;i<ser.Length;i++)
                {
                    listView1.Items.Add((String)ser[i]);
                }
                
                

            }



        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window2 W2 = new Window2();


            W2.Show();
            this.Close();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Start();

        }





       

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window2 W2 = new Window2();
            W2.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
        private void startapp(object sender, RoutedEventArgs e)
        {
            Start();

        }
        private void stopapp(object sender, RoutedEventArgs e)
        {
            Stop();

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window3 W3 = new Window3();
            W3.Show();
            this.Close();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to Sign out?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {

                this.Hide();
                MainWindow W = new MainWindow();
                W.Show();
                this.Close();

            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {

           

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Stop();



        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            System.ServiceProcess.ServiceController[] services;
            services = System.ServiceProcess.ServiceController.GetServices();
            listBox.Items.Clear();
            for (int i = 0; i < services.Length; i++)
            {
                listBox.Items.Add(services[i].ServiceName);
            }

        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        { if ((string)listBox.SelectedItem != ("") && (string)listBox.SelectedItem != null)
            {
                if (listView1.Items.Contains((string)listBox.SelectedItem))
                {
                    MessageBox.Show("Caution!! you already add " + (string)listBox.SelectedItem + "   to moniter");
                }

                else
                    listView1.Items.Add((string)listBox.SelectedItem);
            }
            else
                MessageBox.Show(" You have no selected any service");
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            listView1.Items.Remove((string)listView1.SelectedItem);
        }
   
        public void Stop()

        {
            try
            {
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped);


                if (sc.Status.Equals(ServiceControllerStatus.Stopped))
                {
                    button.IsEnabled = true;
                    button3.IsEnabled = true;
                    button8.IsEnabled = true;
                    button2.IsEnabled = false;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not stop " + " Service.\n Error : " + ex.Message.ToString());
            }
            finally
            {
                sc.Close();
            }

        }

        public void Start()
        {
            if (listView1.Items.Count != 0)
            {
                try
                {

                    if (sc.Status.Equals(ServiceControllerStatus.Paused))
                    {
                        sc.Continue();
                        sc.WaitForStatus(ServiceControllerStatus.Running);
                        button.IsEnabled = false;
                        button3.IsEnabled = false;
                        button8.IsEnabled = false;
                        button2.IsEnabled = true;


                    }
                    else
                    {
                        List<string> list = new List<string>();
                        List<string> listtxt = new List<string>();
                        list.Add(ConfigUpdate.File.GetSetting("AdminEMail"));



                        string item = string.Empty;
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            list.Add(listView1.Items[i].ToString());
                            listtxt.Add(listView1.Items[i].ToString());

                        }


                        string[] service = list.ToArray();
                        string[] ser = listtxt.ToArray();

                        Log.func.writefile(ser);
                        sc.Start(service);
                        sc.WaitForStatus(ServiceControllerStatus.Running);
                        if (sc.Status.Equals(ServiceControllerStatus.Running))
                        {
                            button.IsEnabled = false;
                            button3.IsEnabled = false;
                            button8.IsEnabled = false;
                            button2.IsEnabled = true;

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not start " + " Service.\n Error : " + ex.Message.ToString());
                }
                finally
                {
                    sc.Close();
                }
            }
        
            else
                MessageBox.Show("You Must have to select atleast one Service before Start");
    }
}
}
