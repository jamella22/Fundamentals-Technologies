using System;
using System.Collections.Generic;
using System.Linq;

namespace Square_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> squareNums = new List<int>();

            foreach (int num in nums)
            {
                if (Math.Sqrt(num) == (int)Math.Sqrt(num))
                {
                    squareNums.Add(num);

                }
            }
            squareNums.Sort();
            squareNums.Reverse();
            Console.WriteLine(string.Join(" ", squareNums));
        }
    }
}
