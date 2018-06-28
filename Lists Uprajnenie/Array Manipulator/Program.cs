using System;
using System.Collections.Generic;
using System.Linq;

namespace Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "print")
            {
                var pieces = input.Split();
                string command = pieces[0];
                if (command == "add")
                {
                    int index = int.Parse(pieces[1]);
                    int element = int.Parse(pieces[2]);
                    array.Insert(index, element);

                }
                if (command == "addMany")
                {  
                    int index = int.Parse(pieces[1]);
                    int[] element = new int[pieces.Length - 2];
                    for (int i = 0; i < element.Length; i++)
                    {
                        element[i] = int.Parse(pieces[i + 2]);
                    }
                    array.InsertRange(index, element);
                }
                if (command == "contains")
                {
                    int element = int.Parse(pieces[1]);
                    Console.WriteLine(array.IndexOf(element));
                    
                }
                if (command == "remove")
                {
                    int index = int.Parse(pieces[1]);
                    array.RemoveAt(index);
                }
                if (command == "shift")
                {
                    int shiftBy = int.Parse(pieces[1]) % array.Count;
                    array = Shift(array, shiftBy);
                }
                if (command == "sumPairs")
                {
                    for (int i = 0; i < array.Count - 1; i++)
                    {
                        array[i] += array[i + 1];
                        array.RemoveAt(i + 1);

                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("["+ string.Join(", " ,array)+ "]");
        }

        private static List<int> Shift (List<int> array,int  shiftBy)
        {
            List<int> result = array.GetRange(shiftBy, array.Count - shiftBy);
            result.AddRange(array.GetRange(0, shiftBy));
            return result;
        }
    }
}
