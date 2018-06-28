using System;
using System.Linq;

namespace P04_Numbers_in_Reversed_Order
{
    class Program
    {
        static void Main()
        {
            decimal number = decimal.Parse(Console.ReadLine());

            decimal reverse = ReverseNumber(number);
            Console.WriteLine(reverse);
        }

        private static decimal ReverseNumber(decimal number)
        {
            decimal d = number;
            string reversedStr = new string(d.ToString().Reverse().ToArray());
            decimal reversedDecimal;
            if (decimal.TryParse(reversedStr, out reversedDecimal))
            {
                return reversedDecimal;
            }
            else
            {
                return 0;
            }
        }
    }
}