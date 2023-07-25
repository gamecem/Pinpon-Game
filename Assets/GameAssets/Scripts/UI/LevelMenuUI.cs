
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class LevelMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuGO;
    [SerializeField] private GameObject LevelsMenuGO;
    [SerializeField] private GameObject GameGO;

    [SerializeField] private Button ReturnToMainMenuButton;
    void Start()
    {
        HandleMainMenuButton();
    }

    private void HandleMainMenuButton()
    {
        ReturnToMainMenuButton.OnClickAsObservable().Do(_ =>
        {
            LevelsMenuGO.SetActive(false);
            GameGO.SetActive(false);
            MainMenuGO.SetActive(true);
        }).Subscribe().AddTo(gameObject);
    }
    
}
