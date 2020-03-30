using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveExtraBlanks
{

    public class Program
    {
        public static bool ParseArgs(string[] args, ref string inputFile, ref string outputFile)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid arguments count");
                Console.WriteLine("Usage: RemoveExtraBlanks.exe <input file> <output file>");
                return false;
            }
            inputFile = args[0];
            outputFile = args[1];
            return true;
        }

        public static string RemoveExtraBlanksInLine(string line)
        {
            string newline = line.Trim();
            newline = RemoveRepetitiveBlanksInLine(newline);
            return newline;

        }
        public static string RemoveRepetitiveBlanksInLine(string line)
        {
            string newLine = "";
            bool flag = false;
            for (int i = 0; i < line.Length; i++)
            {
                if ((line[i] == ' ') || (line[i] == '\t'))
                {
                    if (!flag)
                    {
                        newLine = newLine + line[i];
                    }
                    flag = true;
                }
                else
                {
                    newLine = newLine + line[i];
                    flag = false;
                }
            }
            return newLine;
        }

        public static bool RemoveExtraBlanksInFile(string inputFile, string outputFile)
        {
            if (!File.Exists(inputFile) || !File.Exists(outputFile))
            {
                Console.WriteLine(inputFile + " and/or " + outputFile + " doesn't exists");
                return false;
            }
            StreamReader input = new StreamReader(inputFile);
            StreamWriter output = new StreamWriter(outputFile);
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string newLine = RemoveExtraBlanksInLine(line);
                output.WriteLine(newLine);
            }
            input.Close();
            output.Close();
            return true;
        }

        public static int Main(string[] args)
        {
            string inputFile = "";
            string outputFile = "";
            if (!ParseArgs(args, ref inputFile, ref outputFile))
            {
                return 1;
            }
            if (!RemoveExtraBlanksInFile(inputFile, outputFile))
            {
                return 1;
            }
            return 0;
        }
    }
}
