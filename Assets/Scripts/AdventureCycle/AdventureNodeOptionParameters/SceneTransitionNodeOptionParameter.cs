using SceneManager;
using UnityEngine;

namespace AdventureCycle.AdventureNodeOptionParameters
{
    [CreateAssetMenu(fileName = "AdventureNodeInfo", menuName = "ScriptableObjects/AdventureNodeOptionParameter/SceneTransitionNodeOptionParameter", order = 1)]
    public class SceneTransitionNodeOptionParameter : BaseAdventureNodeOptionParameter
    {
        [SerializeField] int TargetScene;

        public override void OptionParameterAction()
        {
            SceneTransitionManager.Instance.SceneChange(TargetScene, true, UnityEngine.SceneManagement.SceneManager.GetAllScenes()[1].name);
        }
    }
}
