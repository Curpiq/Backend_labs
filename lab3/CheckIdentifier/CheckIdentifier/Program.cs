using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIdentifier
{
    public class Program
    {
        static bool IsLetter(char ch)
        {
            return (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z');
        }
        static bool IsDigit(char digit)
        {
            return (digit >= '0' && digit <= '9');
        }
        public static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("No");
                Console.WriteLine("Invalid arguments count");
                Console.WriteLine("Usage: CheckIdentifier.exe <identifier>");
                return 1;
            }
            string inputString = args[0];
            if (String.IsNullOrEmpty(inputString))
            {
                Console.WriteLine("No");
                Console.WriteLine("The string must not be empty");
                return 1;
            }
            if (IsDigit(inputString[0]))
            {
                Console.WriteLine("No");
                Console.WriteLine("Identifier must be start with letter");
                return 1;
            }
            for (int i = 1; i < inputString.Length; i++)
            {
                if (!IsDigit(inputString[i]) && !IsLetter(inputString[i]))
                {
                    Console.WriteLine("No");
                    Console.WriteLine("Identifier must be contain only letters or digits");
                    return 1;
                }
            }
            Console.WriteLine("Yes");
            return 0;
        }
    }
}
