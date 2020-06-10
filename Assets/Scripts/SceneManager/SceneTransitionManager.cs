using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManager
{
    public class SceneTransitionManager : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] Animator Animator;

        private Dictionary<string, System.Object> TransitionParameters = new Dictionary<string, System.Object>();

        public int LoadedSceneIndex = 0;

        public static SceneTransitionManager Instance;
        void Start()
        {
            Instance = this;
            StartCoroutine(SceneChangeRoutine(1,false));
        }

        public void SceneChange(int indexToLoad, bool unloadScene = true, string unloadName = "")
        {
            StartCoroutine(SceneChangeRoutine(indexToLoad,unloadScene, unloadName));
        }

        public void AddTransitionParameter(string objectName,System.Object obj)
        {
            TransitionParameters.Add(objectName, obj);
        }

        public System.Object RetrieveTransitionParameter(string objectName)
        {
            if (!TransitionParameters.ContainsKey(objectName)) return null;
            var transitionParameter = TransitionParameters[objectName];
            TransitionParameters.Remove(objectName);
            return transitionParameter;
        }

        private IEnumerator SceneChangeRoutine(int indexToLoad, bool unloadScene = true, string unloadName = "")
        {
            SceneExit();

            yield return new WaitForSeconds(1); 

            if (unloadScene)
            {
                UnityEngine.SceneManagement.SceneManager.UnloadScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName(unloadName));
            }

            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(indexToLoad, LoadSceneMode.Additive);
        
            LoadedSceneIndex = indexToLoad;
            LoadSceneCallback = (scene, loadMode) =>
            {
                SceneEnter();
                UnityEngine.SceneManagement.SceneManager.sceneLoaded -= LoadSceneCallback;
            };
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += LoadSceneCallback;
        }

        private UnityEngine.Events.UnityAction<Scene, LoadSceneMode> LoadSceneCallback { get; set; }

        private void SceneEnter()
        {
            Animator.SetBool("SceneExit", false); 
            Animator.SetBool("SceneEnter", true);
        }

        private void SceneExit()
        {
            Animator.SetBool("SceneEnter", false);
            Animator.SetBool("SceneExit", true);
        }
    }
}
