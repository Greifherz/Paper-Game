using System;
using System.Collections.Generic;
using AdventureCycle;
using AdventureCycle.AdventureNodeOptionParameters;
using Player;
using SceneManager.SceneTransitionParameters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AdventureScene
{
    public class AdventureController : MonoBehaviour
    {
        [SerializeField] private TMP_Text MainText;
        [SerializeField] private GameObject OptionButton;

        private AdventureInfo AdventureInfo;
        private List<Button> OptionButtons = new List<Button>();

        private PlayerInfo PlayerInfo;

        // Start is called before the first frame update
        void Start()
        {
            PlayerInfo = PlayerInfo.CreateFromPersistence();
            
            if (CycleController.CurrentAdventureCycleState != null)
                AdventureInfo = CycleController.CurrentAdventureCycleState.AdventureNodeInfo.ToAdventureInfo();

            OptionButtons.Add(OptionButton.GetComponent<Button>());

            if (AdventureInfo != null)
            {
                MainText.parseCtrlCharacters = false;
                MainText.text = AdventureInfo.TextContent.Normalize();
                MainText.parseCtrlCharacters = true;

                for (var I = 0; I < AdventureInfo.Options.Count; I++)
                {
                    if(OptionButtons.Count < I+1)
                    {
                        var NewButton = Instantiate(OptionButton, OptionButton.transform.parent);
                        NewButton.name = NewButton.name.Replace("(Clone)", "");
                        OptionButtons.Add(NewButton.GetComponent<Button>());
                    }
                    OptionButtons[I].GetComponentInChildren<Text>().text = AdventureInfo.Options[I].OptionText;
                }
            }

            var Index = 0;
            foreach(var Btn in OptionButtons)
            {
                var TempIndex = Index;
                Btn.onClick.AddListener(() => 
                {
                    OnOptionClick(TempIndex); 
                });
                Index++;
            }
        }

        private void OnOptionClick(int index)
        {
            if (AdventureInfo == null)
            {
                //var nextAdventureInfo = new AdventureInfo
                //{
                //    TextContent = "As you step out, a man you never seen before sets his eyes on you. \n\n \"You! What are you doing here?\" \n\n He then breaks the glass bottle on the nearby post and rushes to you.",
                //    Options = new List<AdventureOption> { new AdventureOption {OptionText = "Defend Yourself" },new AdventureOption() }

                //    //OptionTexts = new List<string> { "Defend Yourself","Run" },
                //    //OptionActions = new List<System.Action<int>> { 
                //    //    (optionIndex) => { SceneTransitionManager.Instance.SceneChange(3, true, "AdventureScene"); },
                //    //    (optionIndex) => { SceneTransitionManager.Instance.SceneChange(1, true, "AdventureScene"); }
                //    //}
                //};

                //SceneTransitionManager.Instance.AddTransitionParameter("AdventureInfo", nextAdventureInfo);
                //SceneTransitionManager.Instance.SceneChange(2, true, "AdventureScene");
            }
            else
            {
                FlattenActions(AdventureInfo.Options[index].OptionComposite.OptionParameters)(index);
                PlayerInfo.PlayerCharacter = PlayerInfo.PlayerCharacter.UpdateCharacter(PlayerInfo.PlayerCharacter, AdventureInfo.Options[index].ExperienceReward);
                PlayerInfo.PersistIntoPersistence();
            }
        }

        private Action<int> FlattenActions(IReadOnlyList<BaseAdventureNodeOptionParameter> optionParameters)
        {
            Action<int> BaseAction = CycleController.SendTrigger;
            for(var I = 0; I < optionParameters.Count; I++)
            {
                BaseAction = Wrap(optionParameters[I].OptionParameterAction, BaseAction);
            }
            return BaseAction;
        }

        private Action<int> Wrap(Action a, Action<int> b)
        {
            return (intParam) => { b(intParam); a(); };
        }
    }
}
