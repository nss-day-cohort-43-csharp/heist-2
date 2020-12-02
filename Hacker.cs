using System;

namespace Heist_2
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialty { get; } = "Hacker";
        
        public void PerformSkill(Bank bank)
        {
           Console.WriteLine($"{Name} is hacking the alarm system. Decreased security {SkillLevel} points!");
           int disableAlarm = bank.AlarmScore - SkillLevel;
           if(disableAlarm <= 0)
           {
               Console.WriteLine($"{Name} has disabled the alarm system!");
           }
      
        }
    }
}