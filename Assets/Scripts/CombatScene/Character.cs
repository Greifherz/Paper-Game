using System;
using CombatScene.Interfaces;

namespace CombatScene
{
    [Serializable]
    public class Character : ICharacter
    {
        public Character()
        {

        }

        public Character(string name)
        {
            MaxHitPoints = CurrentHitPoints = 3;
            MaxManaPoints = CurrentManaPoints = 0;
            Attack = 1;
            Defense = 0;
            Name = name;
        }

        public Character(string name,int hp,int mp, int atk, int def)
        {
            MaxHitPoints = CurrentHitPoints = hp;
            MaxManaPoints = CurrentManaPoints = mp;
            Attack = atk;
            Defense = def;
            Name = name;
        }

        public string Name { get; private set; }

        public int MaxHitPoints { get; private set; }
        public int CurrentHitPoints { get; private set; }

        public int MaxManaPoints { get; private set; }
        public int CurrentManaPoints { get; private set; }

        public int Attack { get; private set; }
        public int Defense { get; private set; }

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
