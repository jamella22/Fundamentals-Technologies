﻿using System;

namespace Print_Part_of_the_ASCIIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int stop = int.Parse(Console.ReadLine());

            for (int i = start; i <= stop; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
