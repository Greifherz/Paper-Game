using CombatScene.Events.Interfaces;
using CombatScene.PlayerControl;

namespace CombatScene.Events.Implementations
{
    public class StartTurnPaperEvent : IStartTurnPaperEvent
    {
        public TurnSystem.TurnType StartingTurn { get; private set; }

        public string Content { get; private set; }

        public PaperEventType Type => PaperEventType.Status;

        public void Visit(EventHandler handler)
        {
            handler.Handle(this);
        }

        public StartTurnPaperEvent(TurnSystem.TurnType turnOwner)
        {
            StartingTurn = turnOwner;
            Content = "Starting " + turnOwner.ToString() + " turn";
        }
    }
}
