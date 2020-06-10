using CombatScene.Interfaces;
using Inventory.UsableEffects;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "UsableItem", menuName = "ScriptableObjects/Item/UsableItem", order = 1)]
    public class UsableItem : PaperItem
    {
        public bool CombatOnly;
        public UsableEffect[] OnUseEffects;

        public ICharacter Use(ICharacter useTarget)
        {
            for (var i = 0; i < OnUseEffects.Length; i++)
            {
                useTarget = OnUseEffects[i].OnUse(useTarget);
            }

            return useTarget;
        }
    }
}