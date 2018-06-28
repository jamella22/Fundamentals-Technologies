﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            var count = new SortedDictionary<double, int>();

            foreach (var num in numbers)
            {
                if (count.ContainsKey(num))
                {
                    count[num]++;
                }
                else
                {
                    count.Add(num, 1);
                }
            }
            foreach (var num in count)
            {
                Console.WriteLine($"{num.Key} -> {num.Value} times");
            }
        }
    }
}
