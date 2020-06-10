using System;
using System.Collections.Generic;
using CombatScene.Interfaces;

namespace SceneManager.SceneTransitionParameters
{
    public class CombatInfo 
    {
        public List<ICharacter> Allies { get; set; }
        public List<ICharacter> Enemies { get; set; }

        public Action WinOutcomeOption;
        public Action LoseOutcomeOption;
    }
}
