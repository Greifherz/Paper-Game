using CombatScene.Events.Implementations;
using CombatScene.Events.Interfaces;
using CombatScene.Interfaces;

namespace CombatScene.Events.Dispatchers
{
	public class CombatEventDispatcher 
	{
		private IPaperNotificationSystem NotificationSystem;
		public CombatEventDispatcher(IPaperNotificationSystem notificationSystem)
		{
			NotificationSystem = notificationSystem;
		}

		public void Attack(ICharacter attacker, ICharacter target)
		{
			//GenerateEvent       
			var AttackEvent = new AttackPaperEvent(attacker, target);

			//DispatchEvent
			NotificationSystem.Raise(AttackEvent);
		}

		public void Heal(ICharacter healer, ICharacter target)
		{
			//GenerateEvent
			//DispatchEvent
		}
	}
}
