using CombatScene.Events.Interfaces;
using CombatScene.Interfaces;

namespace CombatScene.Events.Implementations
{
    public class DeathStatusEvent : IDeathStatusEvent
    {
        public ICharacter DeadCharacter { get; private set; }

        public string Content { get; private set; }

        public PaperEventType Type => PaperEventType.Status;

        public void Visit(EventHandler handler)
        {
            handler.Handle(this);
        }

        public DeathStatusEvent(ICharacter deadCharacter) : base()
        {
            DeadCharacter = deadCharacter;
            Content = deadCharacter.Name + " died horribly.";
        }
    }
}
