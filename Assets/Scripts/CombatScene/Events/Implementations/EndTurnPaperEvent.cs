using CombatScene.Events.Interfaces;

namespace CombatScene.Events.Implementations
{
    public class EndTurnPaperEvent : IEndTurnPaperEvent
    {
        public string Content { get; private set; }

        public PaperEventType Type => PaperEventType.Status;

        public bool IsLoggable { get; private set; }

        public void Visit(EventHandler handler)
        {
            handler.Handle(this);
        }
        public EndTurnPaperEvent(bool loggable = false)
        {
            IsLoggable = loggable;
            Content = "Turn ended";
        }
    }
}
