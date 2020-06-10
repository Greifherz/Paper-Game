using System;

namespace CombatScene.Events.Interfaces
{
    public interface IPaperNotificationSystem
    {
        void Raise(IPaperEvent paperEvent);
        void RegisterListener(Action<IPaperEvent> listenAction);
        void UnregisterListener(Action<IPaperEvent> listenAction);
    }
}