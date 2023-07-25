
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuGO;
    [SerializeField] private GameObject LevelsMenuGO;

    [SerializeField] private Button ReturnToMainMenuButton;
    private GameObject[] LevelPlayButtons;
    void Start()
    {
        StartCoroutine(FindButtons());
        HandleMainMenuButton();
        HandleLevelPlayButton();
    }

    private void HandleMainMenuButton()
    {
        ReturnToMainMenuButton.OnClickAsObservable().Do(_ =>
        {
            LevelsMenuGO.SetActive(false);
            MainMenuGO.SetActive(true);
        }).Subscribe().AddTo(gameObject);
    }
    
    private void HandleLevelPlayButton()
    {
        Button levelPlayButton = LevelPlayButtons[0].GetComponent<Button>();
        levelPlayButton.OnClickAsObservable().Do(_ => 
        {
            SceneManager.LoadScene(1);    
        }).Subscribe().AddTo(gameObject);
    }

    IEnumerator FindButtons()
    {
        yield return new WaitForSeconds(0.5f);
        LevelPlayButtons = GameObject.FindGameObjectsWithTag("PlayButton");
    }
}
