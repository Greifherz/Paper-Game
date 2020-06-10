namespace CombatScene.Events.Interfaces
{
    public interface IEndTurnPaperEvent : IStatusPaperEvent
    {
        bool IsLoggable { get; }
    }
}
