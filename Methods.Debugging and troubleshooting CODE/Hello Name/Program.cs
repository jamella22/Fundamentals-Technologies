using System;

namespace Hello_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            input();
        }

        private static void input()
        {
            string name = "Peter";
            Console.WriteLine($"Hello, {name}!");
            return;
        }
    }
}
