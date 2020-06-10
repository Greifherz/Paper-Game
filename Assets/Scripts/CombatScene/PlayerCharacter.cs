using System;
using System.Collections.Generic;
using CombatScene.Interfaces;
using Inventory;
using Newtonsoft.Json;

namespace CombatScene
{

    public class PlayerCharacter : IPlayerCharacter
    {
        public PlayerCharacter()
        {
            EquippedItems = new Dictionary<EquipmentSlot, EquipmentItem>();
        }

        public PlayerCharacter(string name)
        {
            MaxHitPoints = CurrentHitPoints= 10;
            MaxManaPoints = CurrentManaPoints = 5;
            Attack = 1;
            Defense = 0;
            Name = name;
            Experience = 0;
            Level = 0;
            EquippedItems = new Dictionary<EquipmentSlot, EquipmentItem>();
        }

        public string Name { get; set; }

        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }

        public int MaxManaPoints { get; set; }
        public int CurrentManaPoints { get; set; }

        public int Attack { get; set; }
        public int Defense { get; set; }

        public int Experience { get; set; }
        
        public int Level { get; set; }

        public IPlayerCharacter UpdateCharacter(ICharacter combatRepresentation, int gainedExperience)
        {
            CurrentHitPoints = combatRepresentation.CurrentHitPoints;
            CurrentManaPoints = combatRepresentation.CurrentHitPoints;
            Experience += gainedExperience;
            if (Experience <= 100) return this;
            
            Level++;
            Experience -= 100;
            return this;
        }

        [JsonIgnore]public Dictionary<EquipmentSlot, EquipmentItem> EquippedItems { get; }

        public void HpAction(int quantity)
        {
            CurrentHitPoints += quantity;
            if (CurrentHitPoints > MaxHitPoints)
                CurrentHitPoints = MaxHitPoints;
            else if (CurrentHitPoints < 0)
                CurrentHitPoints = 0;
        }

        public void MpAction(int quantity)
        {
            CurrentManaPoints += quantity;
            if (CurrentManaPoints > MaxManaPoints)
                CurrentManaPoints = MaxManaPoints;
            else if (CurrentManaPoints < 0)
                CurrentManaPoints = 0;
        }

        public void OnTurnStart()
        {
            
        }

        public void OnTurnEnd()
        {
            
        }

        public ICharacter Normalize(bool force = false)
        {
            return this;
        }
    }
}