using System;
using System.Collections.Generic;
using System.Linq;

namespace Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string name = string.Empty;
            string value = string.Empty;
            int counter = 1;

            Dictionary<string, string> emails = new Dictionary<string, string>();

            while (input != "stop")
            {
                if (counter % 2 != 0)
                {
                    name = input;
                }
                else
                {
                    value = input;
                    string[] check = value.Split(new char[] { '@', '.' }).ToArray();
                    if (check[check.Length -1] == "us" || check[check.Length - 1] == "uk")
                    {
                        break;
                    }
                    else
                    {
                        emails.Add(name, value);
                    }
                }
                counter++;
                input = Console.ReadLine();
            }
            foreach (KeyValuePair<string, string> email in emails)
            {
                Console.WriteLine($"{email.Key} -> {email.Value} ");
            }
        }
    }
}
