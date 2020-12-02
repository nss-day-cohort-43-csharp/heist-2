using System;

namespace Heist_2
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialty { get; } = "LockSpecialist";
        
        public void PerformSkill(Bank bank)
        {
           Console.WriteLine($"{Name} is unlocking the vault. Decreased security {SkillLevel} points!");
           bank.VaultScore = bank.VaultScore - SkillLevel;
           if(bank.VaultScore <= 0)
           {
               Console.WriteLine($"{Name} has unlocked the vault!");
           }
      
        }
    }
}