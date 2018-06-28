using System;
using System.Collections.Generic;
using System.Linq;

namespace Read_list_from_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string>() { "Nakov", "Angel", "Ivan", "Atanas", "Boris" };
            names.Sort();
            Console.WriteLine(string.Join(", ", names));
            // Angel, Atanas, Boris, Ivan, Nakov
            names.Sort(); names.Reverse();
            Console.WriteLine(string.Join(", ", names));
            // Nakov, Ivan, Boris, Atanas, Angel



        }
    }
}
