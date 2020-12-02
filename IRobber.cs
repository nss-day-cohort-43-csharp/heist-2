namespace Heist_2
{
    public interface IRobber
    {
        string Name();
        int SkillLevel();
        int PercentageCut();
        void PerformSkill(Bank bank);
    }
}