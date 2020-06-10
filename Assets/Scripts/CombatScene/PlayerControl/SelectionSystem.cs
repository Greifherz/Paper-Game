using CombatScene.Interfaces;

namespace CombatScene.PlayerControl
{
    public class SelectionSystem 
    {
        private CombatController CombatController;

        public SelectionSystem(CombatController combatController)
        {
            CombatController = combatController;
        }

        public ICharacter GetSelectedAlly(int index = 0)
        {
            return CombatController.ActiveAllies[index];
        }
        public ICharacter GetSelectedEnemy(int index = 0)
        {
            return CombatController.ActiveEnemies[index];
        }
    }
}
