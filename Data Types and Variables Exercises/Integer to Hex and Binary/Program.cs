﻿using System;

namespace Integer_to_Hex_and_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(Convert.ToString(num, 16).ToUpper());
            Console.WriteLine(Convert.ToString(num, 2));

        }
    }
}
