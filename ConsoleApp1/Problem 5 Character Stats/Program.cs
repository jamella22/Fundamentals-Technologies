using System;

namespace Problem_5_Character_Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int health = int.Parse(Console.ReadLine());
            int healthMax = int.Parse(Console.ReadLine());
            int energy = int.Parse(Console.ReadLine());
            int energyMax = int.Parse(Console.ReadLine());

            string currentHealth = "|" + new string('|', health) + new string('.', healthMax - health) + "|";
            string currentEnergy = "|" + new string('|', energy) + new string('.', energyMax - energy) + "|";

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: {currentHealth}");
            Console.WriteLine($"Energy: {currentEnergy}");
        }
    }
}
