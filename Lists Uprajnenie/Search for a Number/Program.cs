using System;
using System.Collections.Generic;
using System.Linq;

namespace Search_for_a_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstLine = Console.ReadLine().Split().Select(int.Parse).ToList();

            int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numbersToTake = secondLine[0];
            int numbersToDelete = secondLine[1];
            int numbersToSearch = secondLine[2];

            List<int> newnumbers = new List<int>();

            for (int i = 0; i < numbersToTake; i++)
            {
                newnumbers.Add(firstLine[i]);

            }
            newnumbers.RemoveRange(0, numbersToDelete);
            foreach (var num in newnumbers)
            {
                if (num == numbersToSearch)
                {
                    Console.WriteLine("YES!");
                    return;
                }
            }
            Console.WriteLine("NO!");
        }
    }
}
