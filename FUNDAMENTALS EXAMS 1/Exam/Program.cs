using System;

namespace Mie
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGameCount = int.Parse(Console.ReadLine());
            double headSetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double headSet = 0;
            double mouseSet = 0;
            double keyboardSet = 0;
            double displaySet = 0;

            for (int i = 0; i < lostGameCount; i++)
            {
                if (i % 2 != 0)
                {
                    headSet++;
                }
                if (i % 3 != 0)
                {
                    mouseSet++;
                }
            }

            if (headSet == mouseSet)
            {
                keyboardSet++;
            }
            else if (keyboardSet % 2 != 0)
            {
                displaySet++;
            }



        }
    }
}