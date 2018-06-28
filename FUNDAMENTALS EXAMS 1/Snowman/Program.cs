using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowman
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> snowman = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (snowman.Count != 1)
            {
                for (int i = 0; i < snowman.Count; i++)
                {
                    int attacker = i;
                    int target = snowman[i] % snowman.Count;
                    if (snowman[i] == -1)
                    {
                        continue;
                    }
                    int difference = Math.Abs(attacker - target);
                    if (difference == 0)
                    {
                        Console.WriteLine($"{attacker} performed harakiri");
                        snowman[i] = -1;
                    }
                    else
                    {
                        if (difference % 2 == 0)
                        {
                            Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                            snowman[target] = -1;
                        }
                        else
                        {
                            Console.WriteLine($"{attacker} x {target} -> {target} wins");
                            snowman[i] = -1;
                        }
                    }
                    if (snowman.Where(x => !x.Equals(-1)).Count() == 1)
                    {
                        return;
                    }
                }
                snowman = snowman.Where(x => !x.Equals(-1)).ToList();
                
            }

        }
    }
}
