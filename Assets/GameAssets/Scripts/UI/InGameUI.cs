using GameAssets.Scripts.Ball;
using GameAssets.Scripts.Game;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameAssets.Scripts.UI
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text bounceCountText;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private BallGroundCollisionCounter ballCollisionCounter;
        void Start()
        {
            HandleBounceText();
            HandleMainMenuButton();
        }
        private void HandleBounceText()
        {
            ballCollisionCounter.GroundCollisionCount.Subscribe(count =>
            {
                bounceCountText.text = "Bounce Count: " + count;
            }).AddTo(gameObject);
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
