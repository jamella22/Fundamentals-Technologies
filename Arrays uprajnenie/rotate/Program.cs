using System;
using System.Collections.Generic;
using System.Linq;

namespace rotate
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rotations = int.Parse(Console.ReadLine());

            int[] sumArray = new int[arr.Length];


            for (int i = 0; i < rotations; i++)
            {
                Shift(arr);
                Sum(sumArray, arr);
            }

            Console.WriteLine(string.Join(" ", sumArray));
        }

        private static void Sum(int[] sumArray, int[] arr)         // sum loop na masiv
        {
            for (int i = 0; i < sumArray.Length; i++)
            {
                sumArray[i] += arr[i];
            }
        }

        private static void Shift(int[] arr)                         // SHIFT 1 2 3 1 stava 3 1 2 ;

        {
            int last = arr[arr.Length - 1];

            for (int i = arr.Length - 1; i > 0; i--)
            {
                arr[i] = arr[i - 1];

            }
            arr[0] = last;

        }

        private static int[] ParseArray(string input)             // INT MASIV
        {
            string[] tokens = input.Split();
            int[] result = new int[tokens.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = int.Parse(tokens[i]);
            }
            return result;
        }
    }
}
