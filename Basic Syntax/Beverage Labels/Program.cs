using System;

namespace Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double volume = double.Parse(Console.ReadLine());
            double energyper100 = double.Parse(Console.ReadLine());
            double sugarper100 = double.Parse(Console.ReadLine());

            double energyTotal = 1 * energyper100 * volume / 100;
            double sugarTotal = 1 * sugarper100 * volume / 100;

            Console.WriteLine($"{volume}ml {name}:\r\n{energyTotal}kcal, {sugarTotal}g sugars");


        }
    }
}
