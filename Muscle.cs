using System;

namespace Heist_2
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        
        public void PerformSkill(Bank bank)
        {
           Console.WriteLine($"{Name} is beating up the security guard. Decreased security {SkillLevel} points!");
           int kill = bank.SecurityGuardScore - SkillLevel;
           if(kill <= 0)
           {
               Console.WriteLine($"{Name} has expired the security guard!");
           }
      
        }
    }
}