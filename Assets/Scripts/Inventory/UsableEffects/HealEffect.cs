using CombatScene.Interfaces;
using UnityEngine;

namespace Inventory.UsableEffects
{
    [CreateAssetMenu(fileName = "HealEffect", menuName = "ScriptableObjects/Item/UsableEffect/HealEffect", order = 1)]
    public class HealEffect : UsableEffect
    {
        public override ICharacter OnUse(ICharacter usingCharacter)
        {
            usingCharacter.HpAction(5);
            return usingCharacter;
        }
    }
}