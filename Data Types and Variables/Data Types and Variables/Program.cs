using System;

namespace Data_Types_and_Variables
{
    class Program
    {
        static void Main(string[] args)
        {

            double radius = double.Parse(Console.ReadLine());
            double baba = Math.PI * Math.Pow(radius, 2);

            Console.WriteLine($"{baba:F12}");
        }
    }
}
