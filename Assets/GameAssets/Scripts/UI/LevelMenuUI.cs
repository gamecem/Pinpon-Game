
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

public class LevelMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuGO;
    [SerializeField] private GameObject LevelsMenuGO;
    [SerializeField] private Button ReturnToMainMenuButton;
    
    private Button[] playButtons;
    void Start()
    {
        HandleMainMenuButton();
    }

    private void HandleMainMenuButton()
    {
        ReturnToMainMenuButton.OnClickAsObservable().Do(_ =>
        {
            LevelsMenuGO.SetActive(false);
            MainMenuGO.SetActive(true);
        }).Subscribe().AddTo(gameObject);
    }
   
   
}
