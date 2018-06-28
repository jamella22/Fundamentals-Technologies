using System;

namespace FUNDAMENTALS_EXAMS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double cash = double.Parse(Console.ReadLine());
            double guests = double.Parse(Console.ReadLine());
            double pricePerBanana = double.Parse(Console.ReadLine());
            double pricepPerEggs = double.Parse(Console.ReadLine());
            double priceBerriesKilo = double.Parse(Console.ReadLine());


            double quantity = 0;

            double portionsOfSix = (pricePerBanana * 2 + pricepPerEggs * 4 + priceBerriesKilo * 0.2);

            double portionForOne = portionsOfSix / 6;

            if (guests > 6)
            {
                portionsOfSix = portionsOfSix * 2;
                Console.WriteLine(portionsOfSix);
            }
            else if (guests != 6)
            {
                quantity = portionForOne * guests;
                Console.WriteLine(quantity);
            }
           
           f
            
            
            //else
            //{

            //}
        }
    }
}
