using System;
using System.Collections.Generic;

namespace Heist_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> rolodex = new List<IRobber>()
            {
                new Hacker
                {
                    Name = "Tim",
                    SkillLevel = 35,
                    PercentageCut = 60,
                },
                new Hacker
                {
                    Name = "BobPete",
                    SkillLevel = 55,
                    PercentageCut = 10,
                },
                new Muscle
                {
                    Name = "Sara",
                    SkillLevel = 45,
                    PercentageCut = 25,
                },
                new Muscle
                {
                    Name = "BobJoe",
                    SkillLevel = 55,
                    PercentageCut = 10,
                },
                new LockSpecialist
                {
                    Name = "Gus",
                    SkillLevel = 25,
                    PercentageCut = 30,
                },
                new LockSpecialist
                {
                    Name = "BobBob",
                    SkillLevel = 55,
                    PercentageCut = 10,
                }
            };
            

            while(true)
            {

                Console.WriteLine(rolodex.Count);
                Console.Write("Enter crew member's name: ");
                string name = Console.ReadLine();
                if(name == "")
                {
                    break;
                }

                int speciality = 0;
                while(true)
                {
                    Console.WriteLine(@"
1. Hacker (Disables alarms)
2. Muscle (Disarms guards)
3. Lock Specialist (Cracks vault)
                    ");
                    try
                    {
                        speciality = int.Parse(Console.ReadLine());
                        if(speciality > 0 && speciality < 4)
                        {

                            break;
                        }
                    
                    }
                    catch 
                    {
                        Console.WriteLine("Enter a number 1-3");
                    }
                
                }

                int skill = 0;
                while(true)
                {
                    Console.Write("Enter crew member's skill (1-100): ");
                    try
                    {
                        skill = int.Parse(Console.ReadLine());
                        if(skill > 0 && skill <= 100)
                        {
                            break;
                        }
                    
                    }
                    catch 
                    {
                        Console.WriteLine("Enter a number 1-100");
                    }
                
                }

                int percent = 0;
                while(true)
                {
                    Console.Write("Enter crew member's percentage cut (1-100): ");
                    try
                    {
                        percent = int.Parse(Console.ReadLine());
                        if(percent > 0 && percent <= 100)
                        {
                            break;
                        }
                    
                    }
                    catch 
                    {
                        Console.WriteLine("Enter a number 1-100");
                    }
                
                }
        
                switch(speciality)
                {
                    case 1:
                        var Hacker = new Hacker
                        {
                            Name = name,
                            SkillLevel = skill,
                            PercentageCut = percent
                        };
                        rolodex.Add(Hacker);
                        break;
                    case 2:
                        var Muscle = new Muscle
                        {
                            Name = name,
                            SkillLevel = skill,
                            PercentageCut = percent
                        };
                        rolodex.Add(Muscle);
                        break;
                    case 3:
                        var LockSpecialist = new LockSpecialist
                        {
                            Name = name,
                            SkillLevel = skill,
                            PercentageCut = percent
                        };
                        rolodex.Add(LockSpecialist);
                        break;
                }
            }
        }
    }
}
