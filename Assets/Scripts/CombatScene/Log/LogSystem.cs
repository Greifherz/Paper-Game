using CombatScene.Events.Implementations;
using CombatScene.Events.Interfaces;
using CombatScene.Events.Monobehaviours;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CombatScene.Log
{
    public class LogSystem : Events.EventHandler
    {
        private const string STARTLINE = "-";
        private const string NEWLINE = "\n";

        [FormerlySerializedAs("notificationSystem")] public PaperNotificationSystem NotificationSystem;
        public Text LogText;

        // Start is called before the first frame update
        private void Start()
        {
            NotificationSystem.RegisterListener(Visit);
            var InitStatus = new StatusPaperEvent("Combat Started");
            NotificationSystem.Raise(InitStatus);
        }

        private void LogToConsole(string text,bool clear = false)
        {
            if (clear)
            {
                LogText.text = "";
            }
            
            var NewText = LogText.text + STARTLINE + text + NEWLINE;
            var LogLines = NewText.Split(STARTLINE[0]);
            if (LogLines.Length > 11)
            {
                NewText = "";
                for (var I = 2; I < 12; I++) 
                    NewText += STARTLINE + LogLines[I];
            }
            LogText.text = NewText;
        }

        public override void Visit(IPaperEvent paperEvent)
        {
            paperEvent.Visit(this);
        }

        public override void Handle(ICombatPaperEvent paperEvent)
        {
            var LogString = paperEvent.Attacker.Name + " attacked " + paperEvent.Defender.Name + " causing " + paperEvent.Intensity + " damage!";
            LogToConsole(LogString);
        }

        public override void Handle(IStatusPaperEvent paperEvent)
        {
            var LogString = paperEvent.Content;
            LogToConsole(LogString);
        }

        public override void Handle(IDeathStatusEvent paperEvent)
        {
            var LogString = paperEvent.Content;
            LogToConsole(LogString);
        }

        public override void Handle(IEndTurnPaperEvent paperEvent)
        {
            if (!paperEvent.IsLoggable) return;
            var LogString = paperEvent.Content;
            LogToConsole(LogString);
        }

        public override void Handle(IStartTurnPaperEvent paperEvent)
        {
            var LogString = paperEvent.Content;
            LogToConsole(LogString);
        }

        public override void Handle(ICombatEndStatusPaperEvent paperEvent)
        {
            var LogString = paperEvent.Content;
            LogToConsole(LogString,true);
        }
    }
}
