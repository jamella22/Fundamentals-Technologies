using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Proba
{
    class Program
    {
        static void Main(string[] args)
        {
            string proba = "Поверителност · Условия · Реклама · Вашият избор · Бисквитки ·Още Facebook © 2018";

            string bulgarian = @"(?<bulgarian>[А-Яа-я]*)";
            string english = @"(?<english>[A-Za-z]*)";

            Regex regex = new Regex(bulgarian);
            Regex regex2 = new Regex(english);
            string bulgarianWords = "";
            string englishWords = "";

            if (regex.IsMatch(proba))
            {


                foreach (Match match in regex.Matches(proba))
                {
                    
                    
                        bulgarianWords += match + " ";         

                }

            }
            if (regex2.IsMatch(proba))
            {


                foreach (Match match in regex2.Matches(proba))
                {
                    
                    
                        englishWords += match + " ";
                    

                }
            }
            string[] bulgarian1 = bulgarianWords.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

           
            Console.WriteLine(string.Join(" ",bulgarian1));
            Console.WriteLine(englishWords.Trim());
        }
    }
}
