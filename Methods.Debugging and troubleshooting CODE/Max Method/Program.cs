using System;

namespace Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int maxx = GetMax(a, b);
            maxx = GetMax(maxx, c);
            Console.WriteLine(maxx);
        }

        static int GetMax(int a, int b)
        {
            int maxx = 0;
            if (a > b)
            {
                maxx = a;
            }
            else
            {
                maxx = b;
            }
            return maxx;
        }
    }
}
