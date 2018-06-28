using System;

namespace Miles_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double mile = double.Parse(Console.ReadLine());
            double kilometers = 1.60934;
            double convert = mile * kilometers;
            Console.WriteLine($"{convert:f2}");
        }
    }
}
