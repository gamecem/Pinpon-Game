using GameAssets.Scripts.Game;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.UI
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private Button mainMenuButton;
        void Start()
        {
            HandleMainMenuButton();
        }
        private void HandleMainMenuButton()
        {
            mainMenuButton.OnClickAsObservable().Subscribe(_ =>
            {
                GameManager.Instance.GoToPauseMenu();
            }).AddTo(gameObject);
        }
    }
}
