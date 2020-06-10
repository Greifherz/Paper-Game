using UnityEngine;

namespace Inventory
{
    // [CreateAssetMenu(fileName = "BaseItem", menuName = "ScriptableObjects/Item/BaseItem", order = 1)]
    public abstract class PaperItem : ScriptableObject
    {
        public string Name;
        public int Value;
        public ItemRarity Rarity;
    }
}