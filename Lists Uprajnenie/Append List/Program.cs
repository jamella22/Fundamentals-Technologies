using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_List
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> numbers = Console.ReadLine().Split(new char[] {'|', ' ' },StringSplitOptions.RemoveEmptyEntries).ToList();

            numbers.Reverse();

            
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
