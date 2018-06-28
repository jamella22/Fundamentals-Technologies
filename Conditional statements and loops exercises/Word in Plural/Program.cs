using System;

namespace Word_in_Plural
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            if (word.EndsWith('y'))
            {
                word = word.Remove(word.Length - 1);
                word = word + "ies";
            }
            else if (word.EndsWith("o")|| word.EndsWith("ch") || word.EndsWith("s")
                || word.EndsWith("sh") || word.EndsWith("x") || word.EndsWith("z")
            {
                
            }
        }
    }
}
