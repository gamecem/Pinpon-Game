using GameAssets.Scripts.Game;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameAssets.Scripts.UI
{
    public class LoseGameUI : MonoBehaviour
    {
        [SerializeField] private Button retryButton;
        [SerializeField] private Button mainMenuButton;

        private void Start()
        {
            HandleRetryButton();
            HandleMainMenuButton();
        }

        private void HandleRetryButton()
        {
            retryButton.OnClickAsObservable().Subscribe(_ =>
            {
                var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex);
            }).AddTo(gameObject);
        }
        
        private void HandleMainMenuButton()
        {
            mainMenuButton.OnClickAsObservable().Subscribe(_ =>
            {
                GameManager.Instance.GoToMainMenu();
                SceneManager.LoadScene(0);
            }).AddTo(gameObject);
        }
    }
}

