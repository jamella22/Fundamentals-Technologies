﻿using System;

 
namespace _06.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Console.WriteLine(IsPrime(n));
        }
        private static bool IsPrime(long n)
        {
            if (n == 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            double squareRoot = (int)Math.Floor(Math.Sqrt(n));


            for (int i = 2; i <= squareRoot; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}