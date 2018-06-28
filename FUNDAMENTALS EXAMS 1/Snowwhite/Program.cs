using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> jujeta = new List<Dwarf>();

            string input = Console.ReadLine();

            while (input != "Once upon a time")
            {
                string[] dwarfes = input.Split(new char[] { ' ', '<', '>', ':' }, StringSplitOptions.RemoveEmptyEntries);

                string name = dwarfes[0];
                string hatColor = dwarfes[1];
                int physics = int.Parse(dwarfes[2]);

                //if (jujeta.Where(x => x.Name == name).Count().Equals(0))
                //{
                //    jujeta.Add(new Dwarf(name, hatColor, physics));
                //}
                if (jujeta.Where(x => x.Name == name && x.HatColor == hatColor).Count()> 0)
                {
                    int currentDwarfPhysics = jujeta.FirstOrDefault(x => x.Name == name && x.HatColor == hatColor).Physics;
                    jujeta.FirstOrDefault(x => x.Name == name && x.HatColor == hatColor).Physics = Math.Max(currentDwarfPhysics, physics);

                }
                else
                {
                    jujeta.Add(new Dwarf(name, hatColor, physics));
                }
                input = Console.ReadLine();
            }
            foreach (Dwarf juje in jujeta.OrderByDescending(x => x.Physics).ThenByDescending(n => jujeta.Where(j => j.HatColor == n.HatColor).Count()))
            {
                Console.WriteLine($"({juje.HatColor}) {juje.Name} <-> {juje.Physics}");
            }
        }
    }
    internal class  Dwarf
    {
        public string Name { get; set; } 
        public string HatColor { get; set; } 
        public int Physics { get; set; } 
        
        public Dwarf(string name,string hatColor,int physics)
        {
            Name = name;
            HatColor = hatColor;
            Physics = physics;
        }
    }

}
