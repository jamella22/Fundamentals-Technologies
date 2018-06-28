using System;
using System.Collections.Generic;

namespace nums_remove
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int> { 10, 20, 30, 40, 50, 60 };

            nums.RemoveAt(2);
            nums.Add(100);
            nums.Insert(1, -100);

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
