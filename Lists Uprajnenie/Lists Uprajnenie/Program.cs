using System;
using System.Collections.Generic;

namespace Lists_Uprajnenie
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string>();

            names.Add("Peter");
            names.Add("Maria");
            names.Add("George");

            foreach (var name in names)
            {
                Console.WriteLine(name);
               
                
            }
            names.Remove("Maria");
            Console.WriteLine(string.Join(", " , names));
        }
    }
}
