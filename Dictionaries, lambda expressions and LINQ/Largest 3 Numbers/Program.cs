using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            var sortedNums = numbers.OrderByDescending(x => x);

            var largest3Nums = sortedNums.Take(3);

            Console.WriteLine(String.Join(' ', largest3Nums));
        }
    }
}
