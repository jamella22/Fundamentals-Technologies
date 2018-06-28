using System;
using System.Collections.Generic;
using System.Linq;

namespace Split_by_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
           .Split(new char[]
            {',',';',':','.','!','(',')','"','\'','\\','/','[',']',' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

            List<string> lowercase = new List<string>();
            List<string> mixedcase = new List<string>();
            List<string> uppercase = new List<string>();

            foreach (string word in words)
            {
                if (word.All(char.IsLower))
                {
                    lowercase.Add(word);
                }
                else if (word.All(char.IsUpper))
                {
                    uppercase.Add(word);
                }
                else
                {
                    mixedcase.Add(word);
                }
            }
            Console.WriteLine($"Lower-case: {string.Join(", ", lowercase)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", mixedcase)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", uppercase)}");
        }
    }
}
