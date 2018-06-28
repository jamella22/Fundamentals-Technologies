using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            string command = input[0];

            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            while (command != "END")
            {
                if (command == "A")
                {
                    phoneBook[input[1]] = input[2];

                }
                if (command == "S")
                {
                    if (phoneBook.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"{input[1]} -> {phoneBook[input[1]]} ");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {input[1]} does not exist.");
                    }
                }
                input = Console.ReadLine().Split().ToArray();
                command = input[0];

            }
        }
    }
}
