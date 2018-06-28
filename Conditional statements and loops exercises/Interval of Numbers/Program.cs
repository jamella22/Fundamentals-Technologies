using System;

namespace Interval_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int min = Math.Min(first, second);
            int max = Math.Max(first, second);


            for (int i = min; i <= max; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
