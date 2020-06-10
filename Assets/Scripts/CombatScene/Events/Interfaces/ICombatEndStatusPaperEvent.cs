namespace CombatScene.Events.Interfaces
{
    public interface ICombatEndStatusPaperEvent : IStatusPaperEvent
    {
        bool Win { get; }
        int ExperienceReward { get; }
    }
}