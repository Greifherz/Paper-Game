using CombatScene.Interfaces;
using UnityEngine;

namespace Inventory.UsableEffects
{
    public abstract class UsableEffect : ScriptableObject
    {
        public abstract ICharacter OnUse(ICharacter usingCharacter);
    }
}