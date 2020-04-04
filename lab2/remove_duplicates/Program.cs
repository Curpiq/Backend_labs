using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remove_duplicates
{
    class Program 
    {
        static bool ParseArg(string[] args, ref string inputString)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage remove_duplicates.exe <input string>");
                return false;
            }
            inputString = args[0];
            return true;
        }

        static int Main(string[] args)
        {
            string inputString = "";
            if (!ParseArg(args, ref inputString))
            {
                return 1;
            }
            inputString = String.Concat(inputString.Distinct());
            Console.WriteLine(inputString);
            return 0;
        }
    }
}
