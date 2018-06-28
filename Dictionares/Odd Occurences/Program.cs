using System;
using System.Collections.Generic;
using System.Linq;

namespace Odd_Occurences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().ToLower().Split().ToList();

            Dictionary<string, int> repeat = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (repeat.ContainsKey(word) == false )
                {
                    repeat.Add(word, 0);
                }
                repeat[word]++;
            }
            List<string> result = new List<string>();

            foreach (KeyValuePair<string, int>word in repeat)
            {
                if (word.Value % 2 != 0 )
                {
                    result.Add(word.Key);
                }

            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
