using System;

namespace Exchange_variables_values
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine($"Before:\r\n a = {a}\r\n b = {b}\r\n" +
                $"After:\r\n a = {b}\r\n b = {a} ");
        }
    }
}
