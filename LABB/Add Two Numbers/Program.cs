using System;

namespace Add_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum1 = int.Parse(Console.ReadLine());
            int sum2 = int.Parse(Console.ReadLine());
            int sum = sum1 + sum2;

            Console.WriteLine($"{sum1} + {sum2} = {sum}");
        }
    }
}
