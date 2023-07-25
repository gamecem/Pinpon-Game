using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button OptionsButton;
    [SerializeField] private Button QuitButton;

    [SerializeField] private GameObject LevelsMenuGO;
    [SerializeField] private GameObject MainMenuGO;
    [SerializeField] private GameObject OptionsMenuGO;
    private void Start()
    {
        HandlePlayButton();
        HandleOptionsButton();
        HandleQuitButton();
    }
    private void HandlePlayButton()
    {
        PlayButton.OnClickAsObservable().Do(_ =>
        {
            LevelsMenuGO.SetActive(true);
            MainMenuGO.SetActive(false);
            OptionsMenuGO.SetActive(false);
        }).Subscribe().AddTo(gameObject);
    }
    private void HandleOptionsButton()
    {
        OptionsButton.OnClickAsObservable().Do(_ =>
        {
            LevelsMenuGO.SetActive(false);
            MainMenuGO.SetActive(false);
            OptionsMenuGO.SetActive(true);
        }).Subscribe().AddTo(gameObject);
    }
    private void HandleQuitButton()
    {
        QuitButton.OnClickAsObservable().Do(_ =>
        {
            Application.Quit();
        }).Subscribe().AddTo(gameObject);
    }



}
