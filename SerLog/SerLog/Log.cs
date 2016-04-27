using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerLog
{
    class Log
    {
        private static Log obj;
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


        public String[] readfile()
        {

          
            String service = null;
            List<String> SER = new List<string>();

            using (StreamReader read = new StreamReader("moniteredservice.txt"))

            {
                
                while ((service = read.ReadLine()) != null)
                {

                    
                  SER.Add((string)service);
                }
                
            }
            return SER.ToArray();

        }


        public void writefile(String[] add)
        {

            using (StreamWriter write = new StreamWriter("moniteredservice.txt"))
            {

                foreach (string s in add)
                {
                    write.WriteLine(s);
                }
            }

        }
        public String readlastError()
        {
            
            String[] message = new String[3];
            int n = 0;
            List<string> text = File.ReadLines(@"C:\Users\Muhammad_Usman\Documents\Visual Studio 2015\Projects\VP-projects2016\MonitorService\MonitorService\bin\Debug\Logfile.txt").Reverse().Take(3).ToList();
            foreach (string s in text)
            {
                message[n] = s;
                n++;
            }

            String error = message[2] + Environment.NewLine + message[1] + Environment.NewLine + message[0];

            return error;

        }


    }
}
