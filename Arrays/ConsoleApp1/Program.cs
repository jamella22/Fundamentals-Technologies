using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int lenght = int.Parse(Console.ReadLine());

            int[] arr = new int[lenght].Select(int.Parse);

            for (int i = 0; i < lenght ; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
        }



    }
}
