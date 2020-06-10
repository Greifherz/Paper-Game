using System.Collections.Generic;
using Inventory;

namespace CombatScene.Interfaces
{
    public interface IPlayerCharacter : ICharacter
    {
        int Experience { get; }
        int Level { get; }

        IPlayerCharacter UpdateCharacter(ICharacter combatRepresentation, int gainedExperience);

        Dictionary<EquipmentSlot, EquipmentItem> EquippedItems { get; }
    }
}