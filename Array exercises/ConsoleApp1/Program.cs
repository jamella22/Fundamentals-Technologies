using System;
using System Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = ParseArray(Console.ReadLine());

        }

        private static int[] ParseArray(string input)
        {
            string[] tokens = input.Split();
            int[] result = new int[tokens.Length];

            for (int i = 0; i <  result.Length; i++)
            {
                result[i] = int.Parse(tokens[i]);
            }
            return result;
        }
    }
}
