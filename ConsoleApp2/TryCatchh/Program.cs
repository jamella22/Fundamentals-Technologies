using System;

namespace TryCatchh
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 0;

            while (true)
            {
                Console.WriteLine("Write youre age:");
                try
                {
                    age = int.Parse(Console.ReadLine());
                    break;

                }
                catch (Exception)
                {
                    Console.WriteLine("Give me a integer!!!");

                }
            }
         
            age++;
            Console.WriteLine($"You will be {age} years old!");
            

            
        }
    }
}
