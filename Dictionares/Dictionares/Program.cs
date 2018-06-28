using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionares
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split().Select(double.Parse).ToList();


          Dictionary<double, int> sort = new Dictionary<double, int>();

            foreach (var num in nums)
            {
                if (!sort.ContainsKey(num))
                {
                    sort.Add(num, 0);
                }
                sort[num]++;
                
                
            }

            foreach (KeyValuePair<double, int> num in sort.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{ num.Key} -> {num.Value}");
            }
        }
    }
}
