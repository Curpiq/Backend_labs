using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remove_duplicates
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No parameters were specified!");
                return 1;
            }
            if (args.Length > 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage remove_duplicates.exe <input string>");
                return 1;
            }
            string newString = args[0];
            for (int i = 0; i < newString.Length; i++)
            {
                int j;
                for (j = i + 1; j < newString.Length;)
                {
                    if (newString[i] == newString[j])
                    {
                        newString = newString.Remove(j, 1);
                    }
                    else j++;
                }
            }
            Console.WriteLine(newString);
            return 0;
        }
    }
}
