using System;
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
using System.Drawing.Printing;
using System.Drawing;

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
            textBox.Text = Log.func.readlastError();
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

        Font verdana10Font;
             StreamReader reader;
        private void button1_Click(object sender, RoutedEventArgs e)
        {


            reader = new StreamReader(@"C:\Users\Muhammad_Usman\Documents\Visual Studio 2015\Projects\VP-projects2016\MonitorService\MonitorService\bin\Debug\Logfile.txt");
            //Create a Verdana font with size 10
          verdana10Font = new Font("Verdana", 10);
            //Create a PrintDocument object
            PrintDocument pd = new PrintDocument();
            //Add PrintPage event handler
            pd.PrintPage += new PrintPageEventHandler(this.PrintTextFileHandler);
            //Call Print Method
            pd.Print();
            //Close the reader
            if (reader != null)
                reader.Close();
        }
        private void PrintTextFileHandler(object sender, PrintPageEventArgs ppeArgs)
        {
            //Get the Graphics object
            Graphics g = ppeArgs.Graphics;
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            //Read margins from PrintPageEventArgs
            float leftMargin = ppeArgs.MarginBounds.Left;
            float topMargin = ppeArgs.MarginBounds.Top;
            string line = null;
            //Calculate the lines per page on the basis of the height of the page and the height of the font
            linesPerPage = ppeArgs.MarginBounds.Height /
            verdana10Font.GetHeight(g);
            //Now read lines one by one, using StreamReader
            while (count < linesPerPage &&
            ((line = reader.ReadLine()) != null))
            {
                //Calculate the starting position
                yPos = topMargin + (count *
                verdana10Font.GetHeight(g));
                //Draw text
                g.DrawString(line, verdana10Font, System.Drawing.Brushes.Black,
                leftMargin, yPos, new StringFormat());
                //Move to next line
                count++;
            }
            //If PrintPageEventArgs has more pages to print
            if (line != null)
            {
                ppeArgs.HasMorePages = true;
            }
            else
            {
                ppeArgs.HasMorePages = false;
            }
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
