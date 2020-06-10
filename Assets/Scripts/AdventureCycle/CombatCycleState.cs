namespace AdventureCycle
{
    public class CombatCycleState : BaseCycleState
    {
        public CombatNodeInfo CombatNodeInfo;

        public override void OnStateEnter()
        {
            CycleController.CurrentAdventureCycleState = null;
            CycleController.CurrentCombatCycleState = this;
        }

        public override void OnStateExit()
        {

        }

        public override void OnStateUpdate()
        {

        }
    }
}
