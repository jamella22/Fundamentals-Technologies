using System;
using System.Text.RegularExpressions;

namespace Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = "";

            for (int i = 0; i < 5; i++)
            {

                text += Console.ReadLine() + "\n";
            }
            string pattern = @"([^A-Za-z0-9]*)\n([0-9_]*)\n([^A-Za-z0-9]*)([0-9_]*)(?<core>[A-Za-z]*)([0-9_]*)([^A-Za-z0-9]*)\n([0-9_]*)\n([^A-Za-z0-9]*)";

            Regex regex = new Regex(pattern);

            if (regex.IsMatch(text))
            {
                Console.WriteLine("Valid");
                Console.WriteLine($"{regex.Match(text).Groups["core"].Value.Length}");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}
