using System;

namespace Restourtant
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            string place = "";
            double price = 0;


            if (guests <= 50)
            {
                place = "Small Hall";
                price += 2500;
            } else if (guests <= 100) {

                place = "Terrace";
                    price += 5000;
            }
            else if (guests <= 120)
            {
                place = "Great Hall";
                    price += 7500;
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }
            switch (package)
            {
                case "Normal":
                    price += 500;
                    price *= 0.95;
             
                    break;
                case "Gold":
                    price += 750;
                    price *= 0.9;
                    break;
                case "Platinum":
                    price += 1000;
                    price *= 0.85;
                    break;
                    
            }
            Console.WriteLine($"We can offer you the {place}\r\nThe price per person is {price / guests:f2}$");
        }
        
    }
}
