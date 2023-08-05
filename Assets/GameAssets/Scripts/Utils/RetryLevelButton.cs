using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameAssets.Scripts.Utils
{
    public class RetryLevelButton : MonoBehaviour
    {
        private const string Ground = nameof(Ground);
        [SerializeField] private Button retryLevelButton;
         
        private GameObject additiveSceneObject;
        private void Start()
        {
            HandleRetryButtonClick();
        }
        private void OnRetryLevelButtonClicked()
        {
            additiveSceneObject = GameObject.FindGameObjectWithTag(Ground);// O sahneye ait bir tane adam bulki o sahneyi silsin Çok salak bir çözüm buna bakmak lazım
            Scene additiveScene = SceneManager.GetSceneByPath(additiveSceneObject.scene.path);
            string currentSceneName = additiveScene.name;
            AdditiveSceneManager.Instance.UnloadAdditiveScene(currentSceneName);
            AdditiveSceneManager.Instance.LoadAdditiveScene(currentSceneName);
        }

        private void HandleRetryButtonClick()
        {
            retryLevelButton.OnClickAsObservable().Subscribe(_ =>
            {
                OnRetryLevelButtonClicked();
            }).AddTo(gameObject);
        }
    }
}