using System;

namespace problem_5_char_FOR_cycle
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



            Console.WriteLine($"Name: {name}");
            Console.Write("Health: |");
           for(int i = 0; i < health; i++)
            {
                Console.Write("|");
            }
            for (int i = 0; i < healthMax - health; i++)
            {
                Console.Write(".");
            }
            Console.WriteLine("|");
            Console.Write("Energy: |");
            for (int i = 0; i < energy; i++)
            {
                Console.Write("|");
            }
            for (int i = 0; i < energyMax - energy ; i++)
            {
                Console.Write(".");
            }
            Console.WriteLine("|");
        }  
    }         
}
