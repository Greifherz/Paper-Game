using System;

namespace AdventureCycle.Data
{
    [Serializable]
    public class AdventureOption 
    {
        public string OptionText;
        public AdventureNodeOptionComposite OptionComposite;
        public int ExperienceReward;
    }
}
