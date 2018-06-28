using System;

namespace Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 0)
            {
                Console.WriteLine(1);

            }
            else
            {
                Console.WriteLine(Fibonacci(n));
            }

            int fib = Fibonacci(n);
        }

        private static int Fibonacci(int n)
        {
            int f1 = 1;
            int f2 = 1;
            int f3 = 1;
            for (int i = 1; i < n; i++)
            {
                f3 = f1 + f2;
                f1 = f2;
                f2 = f3;

            }
            return f3;
            
        }
    }
}
