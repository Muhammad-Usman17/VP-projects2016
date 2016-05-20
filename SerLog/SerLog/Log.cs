using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    class Log
    {
        private static Log obj;

        Font verdana10Font;
        StreamReader reader;
        public static Log func
        {
            get
            {
                if(obj==null)
                {
                    obj = new Log();
                }
                return obj;
            }
        }


        public String[] readfile(String Filepath)
        {

          
            String service = null;
            List<String> SER = new List<string>();

            using (StreamReader read = new StreamReader(Filepath))

            {
                
                while ((service = read.ReadLine()) != null)
                {

                    
                  SER.Add((string)service);
                }
                
            }
            return SER.ToArray();

        }


        public void writefile(String[] add,String Filepath)
        {

            using (StreamWriter write = new StreamWriter(Filepath))
            {

                foreach (string s in add)
                {
                    write.WriteLine(s);
                }
            }

        }
        public void writefilebat(String Service, String Filepath)
        {

            using (StreamWriter write = new StreamWriter(Filepath))
            {

                write.WriteLine("SC delete " + Service);

            }

        }


        public String readlastError()
        {
            
            String[] message = new String[3];
            int n = 0;
            List<string> text = File.ReadLines(ConfigUpdate.File.GetSetting("LogFilePath")).Reverse().Take(3).ToList();
            foreach (string s in text)
            {
                message[n] = s;
                n++;
            }

            String error = message[2] + Environment.NewLine + message[1] + Environment.NewLine + message[0];

            return error;      

        }

        public void PrintFile(String pathoffile)
        {


            reader = new StreamReader(pathoffile);
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

        

    }
}
