using CombatScene.Events.Interfaces;

namespace CombatScene.Events.Implementations
{
    public class StatusPaperEvent : IStatusPaperEvent
    {
        public StatusPaperEvent(string content)
        {
            Content = content;
            Type = PaperEventType.Status;
        }

        public PaperEventType Type { get; private set; }

        public string Content { get; private set; }

        public void Visit(EventHandler handler)
        {
            handler.Handle(this);
        }
    }
}
