using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort_Numbers1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> nums = Console.ReadLine().Split().Select(decimal.Parse).ToList();

            nums.Sort();

            Console.WriteLine(string.Join(" <= ", nums));
        }
    }
}
