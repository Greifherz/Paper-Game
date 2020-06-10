namespace CombatScene.Events.Interfaces
{
    public interface IStatusPaperEvent : IPaperEvent
    {
        string Content { get; }
    }
}
