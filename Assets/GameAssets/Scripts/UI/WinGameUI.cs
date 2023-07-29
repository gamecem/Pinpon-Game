using GameAssets.Scripts.Game;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameAssets.Scripts.UI
{
    public class WinGameUI : MonoBehaviour
    {
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button mainMenuButton;

        private void Start()
        {
            HandleNextLevelButton();
            HandleMainMenuButton();
        }

        private void HandleNextLevelButton()
        {
            nextLevelButton.OnClickAsObservable().Subscribe(_ =>
            {
                // LevelManagerdan anlık leveli çek; 
                GameManager.Instance.StartGame();
                // SceneManager.LoadScene("Level"+LevelManager.CurrentLevel.Value);
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
