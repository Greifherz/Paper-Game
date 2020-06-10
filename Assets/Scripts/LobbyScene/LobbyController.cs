using SceneManager;
using UnityEngine;

namespace LobbyScene
{
    public class LobbyController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }        

        // Update is called once per frame
        void Update()
        {

        }

        public void OnNewGameClicked()
        {
            //var infoToSend = new CombatInfo();
            //var hero = new Character("Hero",UnityEngine.Random.Range(5,10), UnityEngine.Random.Range(3,5), UnityEngine.Random.Range(2,4), UnityEngine.Random.Range(1,3));
            //var villain = new Character("Villain", UnityEngine.Random.Range(10, 20), UnityEngine.Random.Range(10, 15), UnityEngine.Random.Range(3, 5), UnityEngine.Random.Range(0, 2));
            //infoToSend.Allies = new List<ICharacter> { hero };
            //infoToSend.Enemies = new List<ICharacter> { villain };

            //SceneTransitionManager.Instance.AddTransitionParameter("CombatInfo", infoToSend);
            SceneTransitionManager.Instance.SceneChange(2, true, "Lobby");
        }
    }
}
