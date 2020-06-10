using System;
using System.Collections.Generic;
using AdventureCycle.Data;
using CombatScene;
using CombatScene.Interfaces;
using SceneManager.SceneTransitionParameters;
using UnityEngine;

namespace AdventureCycle
{
    [CreateAssetMenu(fileName = "CombatNodeInfo", menuName = "ScriptableObjects/CombatNodeInfo", order = 1)]
    public class CombatNodeInfo : ScriptableObject
    {
        [SerializeField] CombatDescriptor CombatDescriptor;

        //GetPlayerCharacter from somewhere!

        public int GetExperienceReward(bool win)
        {
            return !win ? 0 : CombatDescriptor.ExperienceReward;
        }
        
        public CombatInfo ToCombatInfo()
        {
            return new CombatInfo
            {
                Allies = new List<ICharacter>(),
                Enemies = new List<ICharacter> { new Character(CombatDescriptor.Name,CombatDescriptor.HitPoints,CombatDescriptor.ManaPoints,CombatDescriptor.Attack,CombatDescriptor.Defense)},
                WinOutcomeOption = FlattenOutcomeOption(CombatDescriptor.WinOutcomeOption),
                LoseOutcomeOption = FlattenOutcomeOption(CombatDescriptor.LoseOutcomeOption)
            };
        }

        private Action FlattenOutcomeOption(CombatOutcomeOption option)
        {
            Action BaseAction = () => { };

            for(var I = 0; I < option.OptionParameters.Count; I++)
            {
                BaseAction = Wrap(option.OptionParameters[I].OptionParameterAction, BaseAction);
            }

            return BaseAction;
        }

        private Action Wrap(Action a, Action b)
        {
            return () => { a(); b(); };
        }
    }
}
