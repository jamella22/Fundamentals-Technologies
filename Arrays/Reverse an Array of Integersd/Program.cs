using System;
using System.Linq;


namespace Reverse_an_Array_of_Integersd
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
                
                
                
            }
            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(array[i]+ " ");

            }
            Console.WriteLine();
        }

    }
}
