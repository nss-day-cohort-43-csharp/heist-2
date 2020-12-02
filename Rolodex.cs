using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist_2
{
    public class Rolodex
    {
        string name { get; set; }
        public static void Print(List<IRobber> rolodex)
        {
            Console.WriteLine("Current contacts");
            Console.WriteLine("------------------");
            int count = 0;
            foreach (var crew in rolodex)
            {
                Console.WriteLine($"Select by Index: {count}");
                Console.WriteLine($"Name: {crew.Name}");
                Console.WriteLine($"Specialty: {crew.Specialty}");
                Console.WriteLine($"Skill Level: {crew.SkillLevel}");
                Console.WriteLine($"Percent Cut: {crew.PercentageCut}");
                Console.WriteLine("------------------");
                count = count + 1;
            }
        }
        public static IRobber SelectMember(List<IRobber> rolodex, int index)
        {

            return rolodex.ElementAt(index);

        }
    }
}