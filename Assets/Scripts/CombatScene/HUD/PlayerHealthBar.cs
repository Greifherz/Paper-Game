using System.Collections;
using CombatScene.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace CombatScene.HUD
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private CombatController CombatController;

        [SerializeField] private Text HealthText;
        [SerializeField] private Image HealthBar;

        private ICharacter PlayerCharacter;
        
        // Start is called before the first frame update
        private IEnumerator Start()
        {
            yield return null;
            while (CombatController.ActiveAllies.Count < 1)
            {
                yield return null;
            }
            PlayerCharacter = CombatController.ActiveAllies[0];
        }

        // Update is called once per frame
        private void Update()
        {
            if (PlayerCharacter == null) return;
            
            HealthText.text = "<b>" + PlayerCharacter.CurrentHitPoints + "//" + PlayerCharacter.MaxHitPoints + "</b>";
            HealthBar.fillAmount = (float)PlayerCharacter.CurrentHitPoints / PlayerCharacter.MaxHitPoints;
        }
    }
}
