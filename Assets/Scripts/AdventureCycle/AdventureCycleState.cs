namespace AdventureCycle
{
    public class AdventureCycleState : BaseCycleState
    {
        public AdventureNodeInfo AdventureNodeInfo;

        public override void OnStateEnter()
        {
            CycleController.CurrentCombatCycleState = null;
            CycleController.CurrentAdventureCycleState = this;
        }

        public override void OnStateExit()
        {

        }

        public override void OnStateUpdate()
        {

        }
    }
}
