using CombatScene.Events.Interfaces;
using UnityEngine;

namespace CombatScene.Events
{
    public abstract class EventHandler : MonoBehaviour, IPaperEventListener
    {
        public abstract void Visit(IPaperEvent paperEvent);

        public virtual void Handle(ICombatPaperEvent paperEvent) { }
        public virtual void Handle(IStatusPaperEvent paperEvent) { }
        public virtual void Handle(IDeathStatusEvent paperEvent) { }
        public virtual void Handle(IStartTurnPaperEvent paperEvent) { }
        public virtual void Handle(IEndTurnPaperEvent paperEvent) { }

        public virtual void Handle(ICombatEndStatusPaperEvent paperEvent) { }

    }
}
