using System;

namespace Summ_odd_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            do
            {
                number++;
                Console.WriteLine(number);
                
            } while (number < 10);

        }
    }
}
