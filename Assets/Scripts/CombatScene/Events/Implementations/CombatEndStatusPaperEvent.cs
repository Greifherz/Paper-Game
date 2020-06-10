using CombatScene.Events.Interfaces;

namespace CombatScene.Events.Implementations
{
    public class CombatEndStatusPaperEvent : ICombatEndStatusPaperEvent
    {
        public CombatEndStatusPaperEvent(bool win, int experienceReward)
        {
            Win = win;
            ExperienceReward = experienceReward;
        }

        public PaperEventType Type => PaperEventType.Status;
        public void Visit(EventHandler handler)
        {
            handler.Handle(this);
        }

        public string Content => Win ? "You won the battle!" : "You lost the battle.";
        public bool Win { get; private set; }
        public int ExperienceReward { get; private set; }
    }
}