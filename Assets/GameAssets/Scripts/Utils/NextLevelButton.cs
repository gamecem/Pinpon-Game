using System.Text.RegularExpressions;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameAssets.Scripts.Utils
{
    public class NextLevelButton : MonoBehaviour
    {
        private const string Ground = nameof(Ground);
        
        [SerializeField] private Button nextLevelButton;
        private GameObject additiveSceneObject;
        private void Start()
        {
            nextLevelButton.OnClickAsObservable().Subscribe(_ =>
            {
                OnNextLevelButtonClicked();
            }).AddTo(gameObject);
        }
        private void OnNextLevelButtonClicked()
        {
            additiveSceneObject = GameObject.FindGameObjectWithTag(Ground);// O sahneye ait bir tane adam bulki o sahneyi silsin Çok salak bir çözüm buna bakmak lazım
            Scene additiveScene = SceneManager.GetSceneByPath(additiveSceneObject.scene.path);
            string currentSceneName = additiveScene.name;
            string levelBase = GetNonNumericPart(currentSceneName);
            string levelNo = GetNumericPart(currentSceneName);
            Debug.Log(levelBase);
            Debug.Log(levelNo);
            int numericLevelNo = int.Parse(levelNo);
            int otherLevel = numericLevelNo + 1;
            
            AdditiveSceneManager.Instance.UnloadAdditiveScene(currentSceneName);
            AdditiveSceneManager.Instance.LoadAdditiveScene(levelBase + "" + otherLevel);
        }
        private static string GetNumericPart(string input)
        {
            return Regex.Match(input, @"\d+").Value;
        }
        private static string GetNonNumericPart(string input)
        {
            return Regex.Replace(input, @"\d+", "");
        }
    }
}