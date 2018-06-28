using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Numb = Console.ReadLine().Split().Select(int.Parse).ToList();

            int[] bomb = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (Numb.Contains(bomb[0]))
            {
                int index = Numb.IndexOf(bomb[0]);
                if ()
                {

                }
            }
        }
    }
}
