using CombatScene.Events.Interfaces;
using CombatScene.Interfaces;

namespace CombatScene.Events.Implementations
{
    public class AttackPaperEvent : ICombatPaperEvent
    {
        public AttackPaperEvent(ICharacter attacker, ICharacter defender)
        {
            Type = PaperEventType.Action;
            Attacker = attacker;
            Defender = defender;

            Intensity = Attacker.Attack - Defender.Defense;
            if (Intensity < 0)
                Intensity = 0;
        }

        public ICharacter Attacker { get; private set; }

        public ICharacter Defender { get; private set; }

        public int Intensity { get; private set; }

        public PaperEventType Type { get; private set; }

        public void Visit(EventHandler handler)
        {
            handler.Handle(this);
        }
    }
}
