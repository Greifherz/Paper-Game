using UnityEngine;

namespace AdventureCycle.AdventureNodeOptionParameters
{
    [CreateAssetMenu(fileName = "AdventureNodeInfo", menuName = "ScriptableObjects/AdventureNodeOptionParameter/ResetStatesNodeOptionParameter", order = 1)]
    public class ResetStatesNodeOptionParameter : BaseAdventureNodeOptionParameter
    {
        public override void OptionParameterAction()
        {
            CycleController.RestartCycle();
        }
    }
}
