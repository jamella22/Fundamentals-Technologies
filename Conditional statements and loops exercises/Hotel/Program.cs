using System;

namespace Conditional_statements_and_loops_exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            double studio = 0;
            double ddouble = 0;
            double suite = 0;

            switch (month)
            {
                case "May":
                case "October":
                    studio += 50 * nightsCount;
                    ddouble += 65 * nightsCount;
                    suite += 75 * nightsCount;
                    if (nightsCount > 7)
                    {
                        studio -= studio * 0.05;
                    }
                    else if (nightsCount > 7)
                    {
                        studio -= 60;
                    }
                    break;
                case "June":
                case "September":
                    studio += 60 * nightsCount;
                    ddouble += 72 * nightsCount;
                    suite += 82 * nightsCount;
                    if (nightsCount > 14)
                    {
                        ddouble -= ddouble * 0.10;
                    }
                    else
                    {
                        studio -= 60;
                    }
                    break;
                default:
                    studio += 68 * nightsCount;
                    ddouble += 77 * nightsCount;
                    suite += 89 * nightsCount;
                    if (nightsCount > 14)
                    {
                        suite -= suite * 0.15;
                    }
                    break;
            }
            Console.WriteLine($"Studio: {studio:f2} lv.");
            Console.WriteLine($"Double: {ddouble:f2} lv.");
            Console.WriteLine($"Suite: {suite:f2} lv.");
        }
    }
}
