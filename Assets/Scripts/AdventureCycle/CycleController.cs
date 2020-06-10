using UnityEngine;

namespace AdventureCycle
{
    public class CycleController : MonoBehaviour
    {
        public static AdventureCycleState CurrentAdventureCycleState;
        public static CombatCycleState CurrentCombatCycleState;

        [SerializeField] Animator StateAnimator;
        private static Animator StateAnimatorInstace;

        private void Awake()
        {
            StateAnimatorInstace = StateAnimator;
        }

        public static void SendTrigger(int optionIndex)
        {
            StateAnimatorInstace.SetTrigger("Option" + optionIndex);
        }

        public static void SendGameOver()
        {
            StateAnimatorInstace.SetTrigger("GameOver");
        }

        public static void RestartCycle()
        {
            StateAnimatorInstace.Rebind();
            CurrentCombatCycleState = null;
            CurrentAdventureCycleState = null;
        }

    }
}
