using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "EquipmentItem", menuName = "ScriptableObjects/Item/EquipmentItem", order = 1)]
    public class EquipmentItem : PaperItem
    {
        public EquipmentSlot Slot;
        public EquipmentModifier[] EquipmentModifiers;
    }
}