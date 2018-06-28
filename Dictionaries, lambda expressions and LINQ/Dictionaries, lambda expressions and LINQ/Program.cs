using System;
using System.Collections.Generic;

namespace Dictionaries__lambda_expressions_and_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> grades =
                new Dictionary<string, double>();

            grades.Add("Mariq", 6.00);
            grades.Add("Pesho", 5.00);
            grades.Add("Gosho", 4.00);
            grades.Add("Stamat", 6.00);

            foreach (var person in grades)
            {
                Console.WriteLine($"{person.Key} -> {person.Value}");
            }

        }
    }
}
