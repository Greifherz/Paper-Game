namespace CombatScene.Events.Interfaces
{
    public interface IPaperEvent
    {
        PaperEventType Type { get; }

        void Visit(EventHandler handler);
    }

    public enum PaperEventType
    {
        Status,
        Action
    }

}
