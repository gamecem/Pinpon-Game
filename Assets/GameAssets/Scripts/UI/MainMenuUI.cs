using GameAssets.Scripts.Game;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.UI
{
    public class MainMenuUI : MonoBehaviour
    { 
        [SerializeField] private Button levelsButton; 
        [SerializeField] private Button optionsButton;
        [SerializeField] private Button quitButton;

        private void Start()
        {
            HandleLevelsButton();
            HandleOptionsButton();
            HandleQuitButton();
        }

        private void HandleLevelsButton()
        {
            levelsButton.OnClickAsObservable().Subscribe(_ =>
            {
                GameManager.Instance.GoToLevelMenu();
            }).AddTo(gameObject);
        }

        private void HandleOptionsButton()
        {
            optionsButton.OnClickAsObservable().Subscribe(_ =>
            {
                GameManager.Instance.GoToOptionsMenu();
            }).AddTo(gameObject);
        }

        private void HandleQuitButton()
        {
            quitButton.OnClickAsObservable().Subscribe(_ =>
            {
                Application.Quit();
            }).AddTo(gameObject);
        }
    }
}