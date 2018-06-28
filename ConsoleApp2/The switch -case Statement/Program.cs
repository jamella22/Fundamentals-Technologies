using System;

namespace The_switch__case_Statement
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());

            switch (months)
            {
               case 1:
                    Console.WriteLine("January");
                    break;

                default:
                    Console.WriteLine("Bye");
                    
                    break;
                    
                case 2:
                    Console.WriteLine("February");
                    break;
            }
        }
        
    }
}
