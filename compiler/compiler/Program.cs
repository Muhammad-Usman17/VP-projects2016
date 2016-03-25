using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

using System.CodeDom.Compiler;

namespace compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press s to write C# code");
            Console.WriteLine("Press F5 to compile code");
            Console.WriteLine("Press ECS to EXIT");

            Console.WriteLine("Enter your option: ");
           
            Char CHOICE = (char)Console.Read();
          
            if (CHOICE=='s')
            {
                Console.Clear();
                writecode();

            }
            else
            {
                Console.WriteLine(" wrong choice: ");
                
            }
            Console.Read();


        }

        public static void writecode()
        {
            string input="";
            Console.WriteLine("Enter your code: ");
            input = Console.ReadLine();
            while(Console.ReadKey(true).Key != ConsoleKey.F5)
            {
                input = input + Console.ReadLine();
           
              
            }
            
            test(input);


        }
        public static void test(string SourceString)
        {

            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            CompilerParameters parameters = new CompilerParameters();
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, SourceString);
            if (results.Errors.Count > 0)
            {
                foreach (CompilerError CompErr in results.Errors)
                {
                    int line = 1;
                   line = line + CompErr.Line;
                    Console.WriteLine(
                         "Line number " + CompErr.Line +
                         ", Error Number: " + CompErr.ErrorNumber +
                         ", '" + CompErr.ErrorText + ";" +
                         Environment.NewLine + Environment.NewLine);
                }
            }
            else
            {
                Console.WriteLine("Success!");


            }

        }
    }
}
