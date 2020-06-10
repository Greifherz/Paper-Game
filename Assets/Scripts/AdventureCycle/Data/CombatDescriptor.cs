using System;

namespace AdventureCycle.Data
{
    [Serializable]
    public class CombatDescriptor
    {
        public string Name;
        public int HitPoints;
        public int ManaPoints;
        public int Attack;
        public int Defense;

        public CombatOutcomeOption WinOutcomeOption;
        public CombatOutcomeOption LoseOutcomeOption;

        public int ExperienceReward;
    }
}
