using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            List<decimal> numbers = Console.ReadLine().Split().Select(decimal.Parse).ToList();

           // 3 3 6 1

            for (int i = 0; i < numbers.Count ; i++)
            {
                for (int j = 0; j < numbers.Count - 1; j++)
                {
                    if (numbers[j] == numbers[j + 1])
                    {
                        numbers[j] += numbers[j + 1];
                        numbers.RemoveAt(j + 1);

                    }

                }
               

            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
