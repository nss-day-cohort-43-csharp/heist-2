using System;

namespace Heist_2
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialty { get; } = "Muscle";
        
        public void PerformSkill(Bank bank)
        {
           Console.WriteLine($"{Name} is beating up the security guard. Decreased security {SkillLevel} points!");
           bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;
           if(bank.SecurityGuardScore <= 0)
           {
               Console.WriteLine($"{Name} has expired the security guard!");
               Console.WriteLine("-------------------");
           }
      
        }
    }
}