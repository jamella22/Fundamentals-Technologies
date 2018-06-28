using System;

namespace Boolean_Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            string yes = Console.ReadLine();
          //  string no = Console.ReadLine();

            bool output = Convert.ToBoolean(yes);
            // bool output2 = Convert.ToBoolean(no);
            if (output)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
           

        }
    }
}
