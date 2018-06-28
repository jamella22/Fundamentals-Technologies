using System;
using System.Linq;

namespace Fold_and_Sum
{
    class Program
    {


        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int k = arr.Length / 4;
            int[] left = GetPart(arr, k, 0);
            int[] middle = GetPart(arr, 2 * k, k);
            int[] right = GetPart(arr, k, 3 * k);


            Array.Reverse(left);
            Array.Reverse(right);

            int[] merged = new int[2 * k];
            int index = 0;
            for (int i = 0; i <  k; i++)
            {
                merged[index++] = left[i];

            }
            for (int i = 0; i < k; i++)
            {

                merged[index++] = right[i];
            }

            for (int i = 0; i < middle.Length; i++)
            {
                int sum = middle[i] + merged[i];
                Console.Write($"{sum} ");
            }

        }

        private static int[] GetPart(int[] arr, int size, int startIndex)
        {
            int[] part = new int[size];
            for (int i = startIndex; i < size + startIndex; i++)
            {
                part[i - startIndex] = arr[i];
            }
            return part;
        }
    }
}
