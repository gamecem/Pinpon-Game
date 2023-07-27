using GameAssets.Scripts.Game;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.UI
{
    public class LevelMenuUI : MonoBehaviour
    {
        [SerializeField] private Button returnToMainMenuButton;

        private void Start()
        {
            HandleMainMenuButton();
        }
        private void HandleMainMenuButton()
        {
            returnToMainMenuButton.OnClickAsObservable().Subscribe(_ =>
            {
                GameManager.Instance.GoToMainMenu();
            }).AddTo(gameObject);
        }
        
        
    }
}