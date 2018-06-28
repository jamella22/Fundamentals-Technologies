using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            int[] result = new int[1000];

            for (int i = 0; i < nums.Count; i++)
            {
                result[nums[i]]++;
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] > 0)
                {
                    Console.WriteLine($"{i} -> {result[i]}");
                }
            }
        }
    }
}
