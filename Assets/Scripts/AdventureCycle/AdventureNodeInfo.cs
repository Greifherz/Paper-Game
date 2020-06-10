using System.Collections.Generic;
using AdventureCycle.Data;
using SceneManager.SceneTransitionParameters;
using UnityEngine;

namespace AdventureCycle
{
    [CreateAssetMenu(fileName = "AdventureNodeInfo", menuName = "ScriptableObjects/AdventureNodeInfo", order = 1)]
    public class AdventureNodeInfo : ScriptableObject
    {
        [SerializeField] [TextArea(5,30)] string MainText;
        [SerializeField] List<AdventureOption> Options;

        public AdventureInfo ToAdventureInfo()
        {
            return new AdventureInfo
            {
                TextContent = MainText,
                Options = Options
            };
        }   
    }
}
