using System;

namespace Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal num = decimal.Parse(Console.ReadLine());

            bool prime = IsPrime(num);
            Console.WriteLine(prime);

        }

        private static bool IsPrime(decimal num)
        {
            if (num <= 1)
            {
                return false;
            }
            else if (num > 1 && num <= 100)
            {


                if (num == 2 || num == 3 || num == 5 || num == 7)
                {
                    return true;
                }
                else if (num % 2 != 0 && num % 3 != 0 && num % 5 != 0 && num % 7 != 0)
                {
                    return false;
                }
            }
          
            else
            {
                return false;
            }
            return true;
        }
    }
}
