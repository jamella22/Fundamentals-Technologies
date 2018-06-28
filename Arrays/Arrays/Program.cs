using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysinEnglish = new string [7] {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
                       };

            int day = int.Parse(Console.ReadLine());

            if (day >= 1 && day <= 7)
            {
                Console.WriteLine(daysinEnglish[day - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }





        }
    }
}
