using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] nums = new int[n];

            double sum = 0;
            double min = 0;
            double max = 0;
            double average = 0;


            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
                sum = nums.Sum();
               min = nums.Min();
                max = nums.Max();
                average = nums.Average();
                
            }
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Average = {average}");

           
        }
    }
}
