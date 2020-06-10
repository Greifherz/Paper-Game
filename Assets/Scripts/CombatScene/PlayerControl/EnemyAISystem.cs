using CombatScene.Events.Dispatchers;
using CombatScene.Events.Interfaces;
using CombatScene.PlayerControl.TurnHandlers;

namespace CombatScene.PlayerControl
{
    public class EnemyAISystem : ITurnHandler
    {
        private CombatController CombatController;

        private CombatEventDispatcher EventDispatcher;
        private TurnEventDispatcher TurnEventDispatcher;

        public EnemyAISystem (IPaperNotificationSystem notificationSystem, CombatController combatController)
        {
            CombatController = combatController;
            EventDispatcher = new CombatEventDispatcher(notificationSystem);
            TurnEventDispatcher = new TurnEventDispatcher(notificationSystem);
        }

        private void EnemyAct()
        {
            var AttackingCharacter = CombatController.ActiveEnemies[0];
            var DefendingCharacter = CombatController.ActiveAllies[0];

            EventDispatcher.Attack(AttackingCharacter, DefendingCharacter);

            TurnEventDispatcher.DispatchEndTurn();
        }

        public void OnTurnStart()
        {
            if(CombatController.ActiveEnemies.Count > 0)
            {
                EnemyAct();
            }
        }
    }
}
