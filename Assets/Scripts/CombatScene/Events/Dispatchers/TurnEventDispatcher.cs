using CombatScene.Events.Implementations;
using CombatScene.Events.Interfaces;
using CombatScene.PlayerControl;

namespace CombatScene.Events.Dispatchers
{
	public class TurnEventDispatcher
	{
		private IPaperNotificationSystem NotificationSystem;

		public TurnEventDispatcher(IPaperNotificationSystem notificationSystem)
		{
			NotificationSystem = notificationSystem;
		}

		public void DispatchEndTurn()
		{
			var EndTurnPaperEvent = new EndTurnPaperEvent();
			NotificationSystem.Raise(EndTurnPaperEvent);
		}

		public void DispatchStartTurn(TurnSystem.TurnType turnOwner)
		{
			var StartTurnPaperEvent = new StartTurnPaperEvent(turnOwner);
			NotificationSystem.Raise(StartTurnPaperEvent);
		}
	}
}
