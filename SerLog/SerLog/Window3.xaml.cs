﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public Window3()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Timer_click);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();

           
        }
        private void Timer_click(object sender, EventArgs e)
        {
            readlastError();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

            Process.Start( @"C:\Users\Muhammad_Usman\Documents\Visual Studio 2015\Projects\VP-projects2016\MonitorService\MonitorService\bin\Debug\Logfile.txt");
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 W = new Window1();

            W.Show();
            this.Close();
        }
        public void readlastError()
        {

            String[] message = new String[3];
           int  n = 0;
            List<string> text = File.ReadLines(@"C:\Users\Muhammad_Usman\Documents\Visual Studio 2015\Projects\VP-projects2016\MonitorService\MonitorService\bin\Debug\Logfile.txt").Reverse().Take(3).ToList();
            foreach(string s in text)
            {
                message[n] = s;
                n++;
            }
            textBox.Text = message[2] + Environment.NewLine + message[1] + Environment.NewLine + message[0];
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to Clear the logfile?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                File.WriteAllText(@"C:\Users\Muhammad_Usman\Documents\Visual Studio 2015\Projects\VP-projects2016\MonitorService\MonitorService\bin\Debug\Logfile.txt", String.Empty);

            }
            
        }
    }
}
