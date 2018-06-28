using System;
using System.Collections.Generic;

namespace A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> resources = new Dictionary<string, int>();

            int counter = 1;
            string key = string.Empty;
            int value = 0;

            while (input != "stop")
            {
                if (counter % 2 != 0)
                {
                    key = input;
                }
                else
                {
                    value = int.Parse(input);
                    if (resources.ContainsKey(key) == false)
                    {
                        resources.Add(key, value);
                    }
                    else
                    {
                        resources[key] += value;
                    }
                }
                counter++;
                input = Console.ReadLine();
            }
            foreach (KeyValuePair<string, int> resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
