using System;
using System.Globalization;

namespace Objects_AND_CLASSES
{
    class DateofWeek
    {
        static void Main(string[] args)
        {
            DateTime input = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(input.DayOfWeek);
        }
    }
}
