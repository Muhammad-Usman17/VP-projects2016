using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows;

namespace SerLog
{    /// <summary>
     /// this  to read, write,print the files ....eg log file 
     /// </summary>
    class Log
    {
        private static Log obj;

        Font verdana10Font;
        StreamReader reader;
        public static Log func
        {
            get
            {
                if (obj == null)
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
        public void writefile(String[] add, String Filepath)
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
            try
            {
                using (StreamWriter write = new StreamWriter(Filepath))
                {

                    write.WriteLine("SC delete " + Service);

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
        public String readlastError()
        {
            String error;
            try
            {
                String[] message = new String[3];
                int n = 0;
                List<string> text = File.ReadLines(ConfigUpdate.File.GetSetting("LogFilePath")).Reverse().Take(3).ToList();
                foreach (string s in text)
                {
                    message[n] = s;
                    n++;
                }

                error = message[2] + Environment.NewLine + message[1] + Environment.NewLine + message[0];

                return error;
            }
            catch (Exception ee)
            {
                error = "Log file is missing";
            }
            return error;

        }
        public void PrintFile(String pathoffile)
        {


            reader = new StreamReader(pathoffile);
            verdana10Font = new Font("Verdana", 10);
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.PrintTextFileHandler);
            pd.Print();
            if (reader != null)
                reader.Close();
        }
        private void PrintTextFileHandler(object sender, PrintPageEventArgs ppeArgs)
        {
            Graphics g = ppeArgs.Graphics;
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ppeArgs.MarginBounds.Left;
            float topMargin = ppeArgs.MarginBounds.Top;
            string line = null;
            linesPerPage = ppeArgs.MarginBounds.Height /
            verdana10Font.GetHeight(g);
            while (count < linesPerPage &&
            ((line = reader.ReadLine()) != null))
            {
                yPos = topMargin + (count *
                verdana10Font.GetHeight(g));
                g.DrawString(line, verdana10Font, System.Drawing.Brushes.Black,
                leftMargin, yPos, new StringFormat());
                count++;
            }

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
