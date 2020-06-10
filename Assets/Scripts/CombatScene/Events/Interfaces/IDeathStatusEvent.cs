using CombatScene.Interfaces;

namespace CombatScene.Events.Interfaces
{ 
    public interface IDeathStatusEvent : IStatusPaperEvent
    {
        ICharacter DeadCharacter { get; }

    }
}
