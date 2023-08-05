using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameAssets.Scripts.Utils
{
    public class AdditiveSceneManager : MonoBehaviour
    {
        private static AdditiveSceneManager instance;

        public static AdditiveSceneManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<AdditiveSceneManager>();

                    if (instance == null)
                    {
                        GameObject singletonObject = new GameObject("AdditiveSceneManager");
                        instance = singletonObject.AddComponent<AdditiveSceneManager>();
                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return instance;
            }
        }

        public void LoadAdditiveScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

        public void UnloadAdditiveScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}