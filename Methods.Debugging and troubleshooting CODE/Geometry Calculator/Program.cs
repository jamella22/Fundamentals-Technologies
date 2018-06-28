using System;

namespace Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                if (isPalindromе(i) && SumDigits7(i) && HasEvenDigit(i)) 
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool HasEvenDigit(int i)
        {
            int current = 0;
            bool hasEven = false;

            while (i != 0)
            {
                current = i % 10;
                if (current % 2 == 0)
                {
                    hasEven = true;
                    return hasEven;
                }
                i /= 10;
            }
            return hasEven;
        }

        private static bool SumDigits7(int i)
        {
            int sumDigit = 0;
            while (i != 0)
            {
                sumDigit += i % 10;
                i /= 10;
            }
            if (sumDigit % 7 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool isPalindromе(int i)
        {
            bool isPalindrome = false;
            int oldNumber = i;
            int reversed = 0;
            int power = i.ToString().Length - 1;
            int loops = i.ToString().Length;

            for (int j = 0; j < loops ; j++)
            {
                reversed += i % 10 * (int)Math.Pow(10, power);
                power--;
                i /= 10;
            }
            if (reversed == oldNumber)
            {
                isPalindrome = true;

            }
            else
            {
                isPalindrome = false;
            }
            return isPalindrome;
        }
    }
}
