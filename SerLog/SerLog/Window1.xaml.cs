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

using System.ServiceProcess;


namespace SerLog
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
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
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window3 W3 = new Window3();
            W3.Show();
            this.Close();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to Sign out?","Confirmation",MessageBoxButton.YesNo,MessageBoxImage.Question);
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
    }
}
