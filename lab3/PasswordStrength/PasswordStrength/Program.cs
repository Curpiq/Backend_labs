using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStrength
{
    public class Program
    {
        public static bool ParseArg(string[] args, ref string password)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid arguments count");
                Console.WriteLine("Usage: PasswordStrength.exe <password>");
                return false;
            }
            password = args[0];
            if (String.IsNullOrEmpty(password))
            {
                Console.WriteLine("The password must not be empty");
                return false;
            }
            if (!IsCorrectPassword(password))
            {
                Console.WriteLine("Password must be contain only letters or digits");
                return false;
            }
            return true;
        }

        static bool IsLetter(char ch)
        {
            return (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z');
        }

        static bool IsDigit(char digit)
        {
            return (digit >= '0' && digit <= '9');
        }

        static bool IsCorrectPassword(string pas)
        {
            for (int i = 0; i < pas.Length; i++)
            {
                if (!IsLetter(pas[i]) && !IsDigit(pas[i]))
                {
                    return false;
                }
            }
            return true;
        }

        static int CountDigits(string pass)
        {
            int count = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                if (IsDigit(pass[i]))
                {
                    count++;
                }
            }
            return count;
        }

        static int CountUpperCaseChars(string pass)
        {
            int count = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] >= 'A' && pass[i] <= 'Z')
                {
                    count++;
                }
            }
            return count;
        }

        static int CountLowCaseChars(string pass)
        {
            int count = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] >= 'a' && pass[i] <= 'z')
                {
                    count++;
                }
            }
            return count;
        }

        public static int CountRepetitiveChars(string pass)
        {
            int count = 0;
            string croppedPass = pass;
            for (int i = 0; i < croppedPass.Length; i++)
            {
                int j;
                bool repeated = false;
                for (j = i + 1; j < croppedPass.Length;)
                {
                    if ((croppedPass[i] == croppedPass[j]) && !repeated)
                    {
                        croppedPass = croppedPass.Remove(j, 1);
                        repeated = true;
                        count += 2;

                    }
                    else if (croppedPass[i] == croppedPass[j])
                    {
                        croppedPass = croppedPass.Remove(j, 1);
                        count++;
                    }
                    else j++;
                }
            }
            return count;
        }

        public static int PasswordRating(string pass)
        {
            int rating = 4 * pass.Length;
            int numberOfDidits = CountDigits(pass);
            if (numberOfDidits == pass.Length || numberOfDidits == 0)
            {
                rating -= pass.Length;
            }
            rating += 4 * numberOfDidits;
            int numberOfCapitalLetters = CountUpperCaseChars(pass);
            if (numberOfCapitalLetters > 0)
            {
                rating += (pass.Length - numberOfCapitalLetters) * 2;
            }
            int numberOfSmallLetters = CountLowCaseChars(pass);
            if (numberOfSmallLetters > 0)
            {
                rating += (pass.Length - numberOfSmallLetters) * 2;
            }
            rating -= CountRepetitiveChars(pass);
            return rating;

        }
        public static int Main(string[] args)
        {
            string password = "";
            if (!ParseArg(args, ref password))
            {
                return 1;
            }
            Console.WriteLine(PasswordRating(password));
            return 0;
        }
    }
}
