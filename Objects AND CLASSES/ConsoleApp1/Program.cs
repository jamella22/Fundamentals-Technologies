using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Random rand = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];

                int randomIndex = rand.Next(0, words.Length );
                words[i] = words[randomIndex];
                words[randomIndex] = currentWord;
            }
            Console.WriteLine(string.Join("\n", words));
        }

    }
}
