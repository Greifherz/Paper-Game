using CombatScene.Interfaces;

namespace CombatScene.Events.Interfaces
{
    public interface ICombatPaperEvent : IPaperEvent
    {
        ICharacter Attacker { get; }
        ICharacter Defender { get; }
        int Intensity { get; }
    }
}
