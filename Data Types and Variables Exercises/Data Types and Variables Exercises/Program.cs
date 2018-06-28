using System;

namespace Data_Types_and_Variables_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string hexaDec = Console.ReadLine();

           int output = Convert.ToInt32(hexaDec, 16);

            Console.WriteLine(output);
        }
    }
}
