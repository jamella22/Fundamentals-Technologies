using System;

namespace Basic_Syntax
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int four = int.Parse(Console.ReadLine());

            Console.WriteLine($"{first:D4} {second:D4} {third:D4} {four:D4}");
        }
    }
}
