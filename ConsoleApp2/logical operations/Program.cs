using System;

namespace logical_operations
{
    class Program
    {
        static void Main(string[] args)
        {

            int  count = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i <= count*2; i++)
            {
                if (i%2 != 0)
                {
                    sum += i;
                    Console.WriteLine(i);
                }
                
            }
            
        }
    }
}
