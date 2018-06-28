using System;

namespace conditional_statements_and_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();

            switch (profession)
            {
                case "Athlete":
                    Console.WriteLine("Water");
                    break;
                case "Bussinessman":
                case "Businesswoman":
                    Console.WriteLine("Coffe");
                    break;
                   
                case "SoftUni Student":
                    Console.WriteLine("beer");
                    break;

                default:
                    Console.WriteLine("Tea");
                    break;
            }

        }
    }
}
