using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorService
{
    public static class logging
    {

        public static void WriteErrorlog(Exception ex)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logfile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + " :" + ex.Source.ToString().Trim() + " ;" + ex.Message.ToString().Trim());
                sw.Flush();
                sw.Close();

            }
            catch

            {

            }

        }
        public static void WriteErrorlog(String Message)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logfile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + " :" + Message);
                sw.Flush();
                sw.Close();

            }
            catch

            {

            }

        }
        public static void Remove()
        {

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Logfile.txt", String.Empty);
        }
    }

}
