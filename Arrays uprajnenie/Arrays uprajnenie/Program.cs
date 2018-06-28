using System;

namespace Arrays_uprajnenie
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();



            int end = Math.Min(arr1.Length, arr2.Length);
            
            int leftcount = 0;
            int rightcount = 0;

            for (int i = 0; i < end; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    leftcount++;
                }
                if (arr1[arr1.Length - i - 1] == arr2[arr2.Length - i - 1])
                {
                    rightcount++;
                }

               
            }
            int max = Math.Max(leftcount, rightcount);
            Console.WriteLine(max);
        }
    }
}
