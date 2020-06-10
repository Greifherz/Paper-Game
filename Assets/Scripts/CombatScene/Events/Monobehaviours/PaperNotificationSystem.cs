using System;
using System.Collections;
using System.Collections.Generic;
using CombatScene.Events.Interfaces;
using UnityEngine;

namespace CombatScene.Events.Monobehaviours
{
    public class PaperNotificationSystem : MonoBehaviour, IPaperNotificationSystem
    {
        private event Action<IPaperEvent> EventPipeline = (paperEvent) => { };

        private Queue<IPaperEvent> EventPool = new Queue<IPaperEvent>();

        public void RegisterListener(Action<IPaperEvent> listenAction)
        {
            EventPipeline += listenAction;
        }

        public void UnregisterListener(Action<IPaperEvent> listenAction)
        {
            EventPipeline -= listenAction;
        }

        public void Raise(IPaperEvent paperEvent)
        {
            EventPool.Enqueue(paperEvent);
        }

        private void Start()
        {
            StartCoroutine(Pooling());
        }

        private IEnumerator Pooling()
        {
            while(gameObject != null)
            {
                for (int i = 0; i < EventPool.Count; i++)
                {
                    EventPipeline(EventPool.Dequeue());
                }

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
