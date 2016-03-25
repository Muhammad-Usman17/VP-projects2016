using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01

{
    class Program
    {




        static void Main(string[] args)
        {
            Program p = new Program();
            string sibling = string.Empty;
            int nos = 0;
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.Write("Please enter the number of siblings: ");
            sibling = Console.ReadLine();

            while (!(Int32.TryParse(sibling, out nos)&&Int32.Parse(sibling)>1))
            {
                Console.Write("Not a valid number, try again.:");

                sibling = Console.ReadLine();
            }

            String[] data = new string[nos];
            DateTime[] doblist = new DateTime[nos];



            for (int i = 0; i < nos; i++)
            {

                Console.Write("Please enter date of birth of sibling  : ");
                string input = Console.ReadLine();
                DateTime dateTime;
                if (DateTime.TryParse(input, out dateTime))
                {
                    data[i] = dateTime.ToString("MM/dd/yyyy").Replace('-', '/'); ;
                }

                doblist[i] = Convert.ToDateTime(data[i]);

            }
            Console.WriteLine("-----------------------------------------------------------------------");
            Array.Sort(doblist);


            for (int j = 0; j < nos; j++)
            {
                int no = j + 1;
                DateTime today = DateTime.Now;
                Console.Write("Age of sibling " + no + "is: ");
                p.dif_fCal(doblist[j], today);
            }


            for (int K = 0; K < nos - 1; K++)
            {
                int no = K + 1;
                Console.Write("Difference between sibling " + no + " and " + (no + 1) + " is: ");
                p.dif_fCal(doblist[K], doblist[K + 1]);
            }

            Console.Read();
        }










        public void dif_fCal(DateTime first, DateTime second)
        {

            var totalDays = (second - first).TotalDays;
            var totalYears = Math.Truncate(totalDays / 365);
            var totalMonths = Math.Truncate((totalDays % 365) / 30);
            var remainingDays = Math.Truncate((totalDays % 365) % 30);
            Console.WriteLine(" {0} years {1} months {2} days", totalYears, totalMonths, remainingDays);

        }





    }
}





