using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button LevelButton;
    [SerializeField] private Button QuitButton;

    [SerializeField] private GameObject LevelsMenuGO;
    [SerializeField] private GameObject MainMenuGO;

    private void Start()
    {
        HandlePlayButton();
        HandleLevelButton();
        HandleQuitButton();
    }
    private void HandlePlayButton()
    {
        PlayButton.OnClickAsObservable().Do(_ =>
        {
            SceneManager.LoadScene(1);
        }).Subscribe().AddTo(gameObject);
    }
    private void HandleLevelButton()
    {
        LevelButton.OnClickAsObservable().Do(_ =>
        {
            LevelsMenuGO.SetActive(true);
            MainMenuGO.SetActive(false);
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
