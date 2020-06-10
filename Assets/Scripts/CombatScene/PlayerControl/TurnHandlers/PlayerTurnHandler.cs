using System;

namespace CombatScene.PlayerControl.TurnHandlers
{
    public class PlayerTurnHandler : ITurnHandler
    {
        private Action TurnStartCallback;

        public PlayerTurnHandler(Action turnStartCallback)
        {
            TurnStartCallback = turnStartCallback;
        }
        public void OnTurnStart()
        {
            TurnStartCallback();
        }
    }
}
