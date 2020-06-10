using System.Collections.Generic;
using CombatScene.Interfaces;
using Inventory;

namespace CombatScene.CharacterDecorators
{
    public static class PlayerCharacterEquipmentDecoratorHelper
    {
        public static IPlayerCharacter DecorateWithEquipmentDecorator(this IPlayerCharacter self)
        {
            return new PlayerCharacterEquipmentDecorator(self);
        }
    }
    
    public class PlayerCharacterEquipmentDecorator : IPlayerCharacter
    {
        private IPlayerCharacter Decoratee;

        public PlayerCharacterEquipmentDecorator(IPlayerCharacter decoratee)
        {
            Decoratee = decoratee;
        }
        
        public string Name => Decoratee.Name;

        public int MaxHitPoints => Decoratee.MaxHitPoints;

        public int CurrentHitPoints => Decoratee.CurrentHitPoints;

        public int MaxManaPoints => Decoratee.MaxManaPoints;

        public int CurrentManaPoints => Decoratee.CurrentManaPoints;

        public int Attack => Decoratee.Attack + GetSummedEquipmentModifierOfAttribute(AttributeType.Attack);

        public int Defense => Decoratee.Defense +  GetSummedEquipmentModifierOfAttribute(AttributeType.Defense);

        public void HpAction(int quantity)
        {
            Decoratee.HpAction(quantity);
        }

        public void MpAction(int quantity)
        {
            Decoratee.MpAction(quantity);
        }

        public void OnTurnStart()
        {
            
        }

        public void OnTurnEnd()
        {
            
        }

        public ICharacter Normalize(bool force = false)
        {
            if (force) return Decoratee.Normalize();
            Decoratee = (IPlayerCharacter)Decoratee.Normalize();
            return (IPlayerCharacter)this;
        }

        public int Experience => Decoratee.Experience;

        public int Level => Decoratee.Level;

        public IPlayerCharacter UpdateCharacter(ICharacter combatRepresentation, int gainedExperience)
        {
            return Decoratee.UpdateCharacter(combatRepresentation, gainedExperience);
        }

        public Dictionary<EquipmentSlot, EquipmentItem> EquippedItems => Decoratee.EquippedItems;

        private int GetSummedEquipmentModifierOfAttribute(AttributeType attribute)
        {
            var Modifier = 0;

            foreach (var KvpEquippedItem in EquippedItems)
            {
                foreach (var KvpModifier in KvpEquippedItem.Value.EquipmentModifiers)
                {
                    if (KvpModifier.Attribute == attribute)
                        Modifier += KvpModifier.ModifierIntensity;
                }
            }
            
            return Modifier;
        }
    }
}