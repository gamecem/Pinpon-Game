using GameAssets.Scripts.Game;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameAssets.Scripts.UI
{
    public class PauseMenuUI : MonoBehaviour
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button mainMenuButton;

        private void Start()
        {
            HandleRetryButton();
            HandleMainMenuButton();
        }

        private void HandleRetryButton()
        {
            resumeButton.OnClickAsObservable().Subscribe(_ =>
            {
                GameManager.Instance.StartGame();
            }).AddTo(gameObject);
        }
        
        private void HandleMainMenuButton()
        {
            mainMenuButton.OnClickAsObservable().Subscribe(_ =>
            {
                //GameManager.Instance.GoToMainMenu();
                SceneManager.LoadScene(0);
            }).AddTo(gameObject);
        }
    }
}
