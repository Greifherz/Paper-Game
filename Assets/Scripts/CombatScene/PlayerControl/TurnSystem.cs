using System.Collections.Generic;
using CombatScene.Events;
using CombatScene.Events.Dispatchers;
using CombatScene.Events.Interfaces;
using CombatScene.Events.Monobehaviours;
using CombatScene.PlayerControl.TurnHandlers;
using UnityEngine;

namespace CombatScene.PlayerControl
{
    public class TurnSystem : EventHandler
    {
        [SerializeField] PaperNotificationSystem NotificationSystem;
        [SerializeField] CombatController CombatController;

        private TurnEventDispatcher EventDispatcher;
        private Dictionary<TurnType, ITurnHandler> TurnHandlers = new Dictionary<TurnType, ITurnHandler>();

        public enum TurnType
        {
            Start = 0,
            Player = 1,
            Enemy = 2 ,
            Scene = 3
        }

        public TurnType CurrentTurnOwner = TurnType.Start;

        private void Start()
        {
            EventDispatcher = new TurnEventDispatcher(NotificationSystem);
            NotificationSystem.RegisterListener(Visit);
            TurnHandlers.Add(TurnType.Enemy, new EnemyAISystem(NotificationSystem, CombatController));
        }

        public void SetPlayerTurnHandler(ITurnHandler playerTurnHandler)
        {
            TurnHandlers.Add(TurnType.Player, playerTurnHandler);
        }

        public void EndTurn()
        {
            var cachedOwner = CurrentTurnOwner;

            do
            {
                cachedOwner++;
                if (cachedOwner > TurnType.Scene)
                    cachedOwner = TurnType.Player;
            } while (!TurnHandlers.ContainsKey(cachedOwner) && cachedOwner != CurrentTurnOwner);


            CurrentTurnOwner = cachedOwner;
            EventDispatcher.DispatchStartTurn(CurrentTurnOwner);
        }
        public override void Visit(IPaperEvent paperEvent)
        {
            paperEvent.Visit(this);
        }

        public override void Handle(IEndTurnPaperEvent paperEvent)
        {
            EndTurn();
        }

        public override void Handle(IStartTurnPaperEvent paperEvent)
        {
            TurnHandlers[paperEvent.StartingTurn].OnTurnStart();
        }

    }
}
