using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02LastKNumberSum
{
    class LastKNumberSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            long[] arr = new long[n];
            arr[0] = 1;
            for (int current = 1; current < arr.Length; current++)
            {
                int start = Math.Max(0, current - k);
                int end = current - 1;
                long sum = 0;
                for (int prev = start; prev <= end; prev++)
                {
                    sum += arr[prev];
                }
                arr[current] = sum;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}