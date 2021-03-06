﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> rolodex = GetRobbers();
            Bank bankToRob = BankForHeist();
            Rolodex.Print(rolodex);
            List<IRobber> crew = new List<IRobber>();
            int percentage = 100;
            while (true)
            {
                Console.WriteLine($"Percentage left for crew members: {percentage}");
                Console.WriteLine("------------------");
                Console.Write("Select a member for your crew from current contacts: ");
                Console.WriteLine("-------------------");
                string input = Console.ReadLine();
                if (input == "")
                {
                    break;
                }
                try
                {
                    int choice = int.Parse(input);
                    if (choice < rolodex.Count && choice >= 0)
                    {
                        IRobber newMember = Rolodex.SelectMember(rolodex, choice);
                        percentage = percentage - newMember.PercentageCut;
                        if (percentage >= 0)
                        {
                            crew.Add(newMember);
                            rolodex.RemoveAt(choice);
                        }
                        else
                        {
                            percentage = percentage + newMember.PercentageCut;
                            Console.WriteLine("Percent cut can't be met for that crew member");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid index number");
                        Console.WriteLine("------------------");
                    }
                }
                catch
                {
                    Console.WriteLine("Enter a valid index number");
                    Console.WriteLine("------------------");
                }
                Rolodex.Print(rolodex);
            }

            crew.ForEach(member => member.PerformSkill(bankToRob));
            if (!bankToRob.IsSecure)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("Heist was a success!!!");
                Console.WriteLine("-------------------");
                int ourCut = bankToRob.CashOnHand;
                foreach (IRobber member in crew)
                {

                    Console.WriteLine($"{member.Name} gets: ${(bankToRob.CashOnHand * member.PercentageCut) / 100}");
                    Console.WriteLine("-------------------");
                    ourCut = ourCut - ((bankToRob.CashOnHand * member.PercentageCut) / 100);
                }
                Console.WriteLine($"You get ${ourCut}");
            }
            else
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("Your crew is locked up!!! **FAILURE**");
            }
        }
        static Bank BankForHeist()
        {
            Bank newBank = new Bank()
            {
                AlarmScore = new Random().Next(0, 101),
                VaultScore = new Random().Next(0, 101),
                SecurityGuardScore = new Random().Next(0, 101),
                CashOnHand = new Random().Next(50000, 1000001)
            };

            Dictionary<string, int> scores = new Dictionary<string, int>()
            {
                { "Alarm", newBank.AlarmScore },
                { "Vault", newBank.VaultScore },
                { "Security Guard", newBank.SecurityGuardScore }
            };

            Console.WriteLine("Recon report for target bank");
            int count = 0;
            foreach (KeyValuePair<string, int> score in scores.OrderByDescending(key => key.Value))
            {
                if (count == 0)
                {
                    Console.WriteLine($"Most secure: {score.Key}");
                }
                if (count == 2)
                {
                    Console.WriteLine($"Least secure: {score.Key}");
                }
                count = count + 1;
            }
            Console.WriteLine("------------------");
            return newBank;
        }
        static List<IRobber> GetRobbers()
        {
            List<IRobber> operatives = new List<IRobber>()
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

            while (true)
            {
                Console.WriteLine($"Your contact list has {operatives.Count} entries.");
                Console.Write("Enter crew member's name to add to contact list: ");
                string name = Console.ReadLine();
                if (name == "")
                {
                    Console.WriteLine("------------------");
                    break;
                }

                int speciality = 0;
                while (true)
                {
                    Console.WriteLine(@"
1. Hacker (Disables alarms)
2. Muscle (Disarms guards)
3. Lock Specialist (Cracks vault)
                    ");
                    try
                    {
                        speciality = int.Parse(Console.ReadLine());
                        if (speciality > 0 && speciality < 4)
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
                while (true)
                {
                    Console.Write("Enter crew member's skill (1-100): ");
                    try
                    {
                        skill = int.Parse(Console.ReadLine());
                        if (skill > 0 && skill <= 100)
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
                while (true)
                {
                    Console.Write("Enter crew member's percentage cut (1-100): ");
                    try
                    {
                        percent = int.Parse(Console.ReadLine());
                        if (percent > 0 && percent <= 100)
                        {
                            break;
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Enter a number 1-100");
                    }

                }

                switch (speciality)
                {
                    case 1:
                        var Hacker = new Hacker
                        {
                            Name = name,
                            SkillLevel = skill,
                            PercentageCut = percent
                        };
                        operatives.Add(Hacker);
                        break;
                    case 2:
                        var Muscle = new Muscle
                        {
                            Name = name,
                            SkillLevel = skill,
                            PercentageCut = percent
                        };
                        operatives.Add(Muscle);
                        break;
                    case 3:
                        var LockSpecialist = new LockSpecialist
                        {
                            Name = name,
                            SkillLevel = skill,
                            PercentageCut = percent
                        };
                        operatives.Add(LockSpecialist);
                        break;
                }
                Console.WriteLine("------------------");
            }
            return operatives;
        }
    }
}
