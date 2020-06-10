using System.Collections.Generic;
using CombatScene.CharacterDecorators;
using CombatScene.Events;
using CombatScene.Events.Dispatchers;
using CombatScene.Events.Interfaces;
using CombatScene.Events.Monobehaviours;
using CombatScene.Interfaces;
using CombatScene.PlayerControl.TurnHandlers;
using Inventory;
using Player;
using UnityEngine;

namespace CombatScene.PlayerControl
{
    public class PlayerController : EventHandler
    {
        [SerializeField] private PaperNotificationSystem NotificationSystem;
        [SerializeField] private CombatController CombatController;
        [SerializeField] private TurnSystem TurnSystem;

        private SelectionSystem SelectionSystem;
        private CombatEventDispatcher CommandDispatcher;
        private TurnEventDispatcher TurnDispatcher;
        private ITurnHandler PlayerTurnHandler;
        private bool HasCurrentTurn = false;
        private PlayerInfo PlayerInfo;

        private ICharacter PlayerCharacter;

        private void Start()
        {
            NotificationSystem.RegisterListener(Visit);
            CommandDispatcher = new CombatEventDispatcher(NotificationSystem);
            TurnDispatcher = new TurnEventDispatcher(NotificationSystem);
            SelectionSystem = new SelectionSystem(CombatController);
            PlayerTurnHandler = new PlayerTurnHandler(OnTurnStart);
            TurnSystem.SetPlayerTurnHandler(PlayerTurnHandler);

            PlayerInfo = PlayerInfo.CreateFromPersistence();

            PlayerCharacter = PlayerInfo.PlayerCharacter.DecorateWithEquipmentDecorator();
            
            CombatController.ActiveAllies = new List<ICharacter>{ PlayerCharacter };
            TurnDispatcher.DispatchEndTurn();
        }

        public void OnAttackClick() 
        {
            if (!HasCurrentTurn) return;
            CommandDispatcher.Attack(SelectionSystem.GetSelectedAlly(), SelectionSystem.GetSelectedEnemy());

            TurnDispatcher.DispatchEndTurn();
            HasCurrentTurn = false;
        }

        private void Update()
        {
            if(Input.GetKey(KeyCode.A))
            {
                PlayerInfo.RetrieveFromPersistence();
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                PlayerInfo.PersistIntoPersistence();
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                PlayerInfo.ClearPersistence();
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                var HealPot = Resources.Load<UsableItem>("Items/Usable/HealPotion");
                PlayerCharacter = HealPot.Use(PlayerCharacter);
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                var RegenPot = Resources.Load<UsableItem>("Items/Usable/RegenPotion");   
                PlayerCharacter = RegenPot.Use(PlayerCharacter); 
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                PlayerCharacter.HpAction(-1);
            }
        }

        private void OnTurnStart()
        {
            HasCurrentTurn = true;
            PlayerCharacter.OnTurnStart();
            PlayerCharacter = PlayerCharacter.Normalize();
        }

        private void OnTurnEnd()
        {
            PlayerCharacter.OnTurnEnd();
            PlayerCharacter = PlayerCharacter.Normalize();
        }

        public override void Visit(IPaperEvent paperEvent)
        {
            paperEvent.Visit(this);
        }

        public override void Handle(ICombatEndStatusPaperEvent paperEvent)
        {
            if (paperEvent.Win)
            {
                PlayerInfo.OptionTrail.Add(0);
            }

            PlayerInfo.PlayerCharacter = PlayerInfo.PlayerCharacter.UpdateCharacter(PlayerCharacter.Normalize(true), paperEvent.ExperienceReward);
            
            PlayerInfo.PersistIntoPersistence();
        }
    }
}
