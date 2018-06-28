using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string beverage = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energyContetPer100 = int.Parse(Console.ReadLine());
            int sugarContentPer100 = int.Parse(Console.ReadLine());

            double energyTotal = 1.0 * energyContetPer100 * volume / 100;
            double sugarTatal = 1.0 * sugarContentPer100 * volume / 100;
            Console.WriteLine($"{volume}ml {beverage}:\r\n{energyTotal}kcal, {sugarTatal}g sugars");
        }
    }
}
