using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace print_args
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
            Console.WriteLine("Number of arguments: " + args.Length);
            Console.WriteLine("Arguments: " + String.Join(" ", args));
            return 0;
        }
    }
}
