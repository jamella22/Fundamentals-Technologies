using System;

namespace Choose_a_Drink
{
    class Program
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = 0;

            switch (profession)
            {

                case "Athlete":
                    price = 0.7;
                    break;
                case "Businessman":
                case "Businesswoman":
                    price = 1;
                    break;
                case "SoftUni Student":
                    price = 1.7;
                    break;
                default:
                    price = 1.2;
                    break;

            }
            Console.WriteLine($"The {profession} has to pay {quantity * price:f2}.");
        }
    }
}
