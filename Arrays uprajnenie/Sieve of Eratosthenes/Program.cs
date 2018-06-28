using System;

namespace Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read input
            //Array
            //Set Values tur
            // 0 = 1 = false
            //find True => set
            //Print


            int endNumber = int.Parse(Console.ReadLine());

            bool[] primeValues = new bool[endNumber + 1];

            for (int i = 0; i < primeValues.Length; i++)
            {
                primeValues[i] = true;
            }
            primeValues[0] = false;
            primeValues[1] = false;

            for (int i = 2; i < primeValues.Length; i++)
            {
                if (primeValues[i])
                {

                }
            }
        }
    }
}
