using System;

namespace Array_exercises
{
    class Program
    {
        static void Main(string[] args)
        {


            int[] arr = new int[5] { 1, 2, 3, 4, 5};
            int[] reversed = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                reversed[i] = arr[arr.Length - i - 1];
            }
            Console.WriteLine(string.Join(" ", reversed);
            
        
        }
    }
}
Array.Reverse(arr);

            Console.WriteLine(string.Join(" ", arr));