using System;
using System.Collections.Generic;
using System.Linq;

namespace Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            int size = input.Count / 4;

            List<int> topLeft = new List<int>();
            List<int> topRight = new List<int>();
            List<int> top = new List<int>();     
            List<int> bottom = new List<int>();

            // 5 2 3 6

            topLeft.AddRange(input.Take(size));  // 5
            topLeft.Reverse(); // 5
            input.Reverse(); 
            topRight.AddRange(input.Take(size)); // 6
            input.Reverse();
            bottom.AddRange(input.Skip(size).Take(size * 2)); // 2 3

            top.AddRange(topLeft.Concat(topRight)); // 5 6
            // top - 2 1 8 7
            // bottom = 3 4 5 6

            IEnumerable<int> Ime = top.Select((x, index) => x + bottom[index]);

            Console.WriteLine(string.Join(" ", Ime));

        }
    }
}
