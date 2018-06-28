using System;
using System.Collections.Generic;
using System.Linq;

namespace Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "Even" || input != "Odd")
            {
                string[] pieces = input.Split();
                string command = pieces[0];

                if (command == "Delete")
                {
                    int element = int.Parse(pieces[1]);
                    nums.RemoveAll(x => x == element);
                }
                else if (command == "Insert")
                {
                    int element = int.Parse(pieces[1]);
                    int index = int.Parse(pieces[2]);
                    nums.Insert(index, element);
                }
                if (input == "Odd")
                {
                    GetOddNumbers(nums);
                }
                else if (input == "Even")
                {
                    GetEvenNumbers(nums);
                }
                input = Console.ReadLine();
            }
        }

        static void GetEvenNumbers(List<int> nums)
        {
            foreach (int num in nums)
            {
                if (num % 2 == 0)
                {
                    Console.Write(num + " ");
                }
            }
            Console.WriteLine();
        }

         static void GetOddNumbers(List<int> nums)
        {
            foreach (int num in nums)
            {
                if (num % 2 != 0)
                {
                    Console.Write(num + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
