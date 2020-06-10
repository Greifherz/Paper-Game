using System.Collections.Generic;
using AdventureCycle;
using CombatScene.Events.Implementations;
using CombatScene.Events.Interfaces;
using CombatScene.Events.Monobehaviours;
using CombatScene.Interfaces;
using SceneManager.SceneTransitionParameters;
using UnityEngine;

namespace CombatScene
{
    public class CombatController : Events.EventHandler
    {
        public PaperNotificationSystem NotificationSystem;
        private CombatInfo CombatInfo { get; set; }

        public GameObject EndCombatPanel;

        public List<ICharacter> ActiveAllies;
        public List<ICharacter> ActiveEnemies;

        private void Start()
        {
            NotificationSystem.RegisterListener(Visit);
            StartCombat();
        }

        private void StartCombat()
        {
            //Setups all agents
            if (CycleController.CurrentCombatCycleState != null)
                CombatInfo = CycleController.CurrentCombatCycleState.CombatNodeInfo.ToCombatInfo();

            if (CombatInfo == null)
            {
                CombatInfo = new CombatInfo
                {
                    Allies = new List<ICharacter> {new Character("Hero")},
                    Enemies = new List<ICharacter> {new Character("Villain")}
                };

            }

            ActiveAllies = new List<ICharacter>(CombatInfo.Allies);
            ActiveEnemies = new List<ICharacter>(CombatInfo.Enemies);
        }

        private void EndCombat()
        {
            //ClearsUp
            EndCombatPanel.SetActive(true);      
            
            var Win = ActiveAllies.Count > 0; 
            
            NotificationSystem.Raise(new CombatEndStatusPaperEvent(Win,CycleController.CurrentCombatCycleState.CombatNodeInfo.GetExperienceReward(Win)));
        }

        public void ChangeScene()
        {
            var Win = ActiveAllies.Count > 0;

            if (Win)
            {
                CycleController.SendTrigger(0);
                CombatInfo.WinOutcomeOption();
            }
            else
            {
                CycleController.SendGameOver();
                CombatInfo.LoseOutcomeOption();
            }
        }

        public override void Visit(IPaperEvent paperCmd)
        {
            paperCmd.Visit(this);
        }

        public override void Handle(ICombatPaperEvent paperCmd)
        {
            paperCmd.Defender.HpAction(-paperCmd.Intensity);
            if(paperCmd.Defender.CurrentHitPoints < 1)
            {
                NotificationSystem.Raise(new DeathStatusEvent(paperCmd.Defender));
            }
        }

        public override void Handle(IDeathStatusEvent paperCmd)
        {
            ActiveAllies.Remove(paperCmd.DeadCharacter);
            ActiveEnemies.Remove(paperCmd.DeadCharacter);

            if(ActiveEnemies.Count == 0 || ActiveAllies.Count == 0)
            {
                EndCombat();
            }
        }
    }
}
