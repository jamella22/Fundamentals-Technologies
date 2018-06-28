using System;
using System.Collections.Generic;
using System.Linq;

namespace Max_Sequence_of_Equal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            11 22 33 55 // 11 222 33 55

            int currentNum = 0;
            int currenLenght = 0;
            int BestLenght = 0;
            int bestNum = 0;
            
            foreach (int num in nums)
            {
                if (num != currentNum)
                {
                    currentNum = num;
                    currenLenght = 0;
                }
                if (num == currentNum)
                {
                    currenLenght++;

                }
                if (currenLenght > BestLenght)
                {
                    BestLenght = currenLenght;
                    bestNum = currentNum;
                }
                
            }
            for (int i = 0; i < BestLenght; i++)
            {
                Console.Write(bestNum + " ");
            }
            Console.WriteLine();
        }
    }
}
