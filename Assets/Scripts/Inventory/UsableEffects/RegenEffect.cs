using CombatScene.CharacterDecorators;
using CombatScene.Interfaces;
using UnityEngine;

namespace Inventory.UsableEffects
{
    [CreateAssetMenu(fileName = "RegenEffect", menuName = "ScriptableObjects/Item/UsableEffect/RegenEffect", order = 1)]
    public class RegenEffect : UsableEffect
    {
        public override ICharacter OnUse(ICharacter usingCharacter)
        {
            return usingCharacter.DecorateWithRegenEffectDecorator(2, 2);
        }
    }
}