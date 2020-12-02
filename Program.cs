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
                },
            };
        }
    }
}
