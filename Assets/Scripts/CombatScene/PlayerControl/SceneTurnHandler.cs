using CombatScene.Events.Dispatchers;
using CombatScene.Events.Interfaces;
using CombatScene.PlayerControl.TurnHandlers;

namespace CombatScene.PlayerControl
{
    public class SceneTurnHandler : ITurnHandler
    {
        private TurnEventDispatcher TurnEventDispatcher;

        private SceneTurnHandler(IPaperNotificationSystem notificationSystem)
        {
            TurnEventDispatcher = new TurnEventDispatcher(notificationSystem);

        }

        public void OnTurnStart()
        {
            TurnEventDispatcher.DispatchEndTurn();
        }
    }
}
