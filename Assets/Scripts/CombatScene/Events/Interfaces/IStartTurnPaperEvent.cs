using CombatScene.PlayerControl;

namespace CombatScene.Events.Interfaces
{
    public interface IStartTurnPaperEvent : IStatusPaperEvent
    {
        TurnSystem.TurnType StartingTurn { get; }
    }
}
