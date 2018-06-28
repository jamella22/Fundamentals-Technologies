using System;

namespace Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            char Gender = char.Parse(Console.ReadLine());
            double id = double.Parse(Console.ReadLine());
            double eln = double.Parse(Console.ReadLine());

            Console.WriteLine($"First Name: {firstName}\r\nLast name: {lastName}\r\nAge: {age}\r\nGender: {Gender}\r\nPersonal ID: {id}\r\nUnique Employee number: {eln}"); 
         
        }
    }
}
