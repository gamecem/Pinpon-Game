using UnityEngine;

namespace GameAssets.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        #region GameViews
        [SerializeField] private GameObject mainMenuGO;
        [SerializeField] private GameObject optionsMenuGO;
        [SerializeField] private GameObject levelMenuGO;
        [SerializeField] private GameObject lostMenuGO;
        [SerializeField] private GameObject winMenuGO;
        [SerializeField] private GameObject pauseMenuGO;
        [SerializeField] private GameObject InGameMenu;
        #endregion

        #region Singleton
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<GameManager>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject("GameManager");
                        instance = obj.AddComponent<GameManager>();
                    }
                }
                return instance;
            }
        }
        #endregion
        private void OnGameStateChange(GameState newState)
        {
            switch (newState)
            {
                case GameState.MainMenu:
                    GoToMainMenu();
                    break;
                case GameState.InGame:
                    StartGame();
                    break;
                case GameState.Lost:
                    GameOver();
                    break;
                case GameState.Win:
                    WinGame();
                    break;
                case GameState.LevelMenu:
                    GoToLevelMenu();
                    break;
                case GameState.OptionsMenu:
                    GoToOptionsMenu();
                    break;
                case GameState.Pause:
                    GoToPauseMenu();
                    break;
            }
        }
        private void ShowMenu(GameObject menuGO)
        {
            mainMenuGO.SetActive(false);
            optionsMenuGO.SetActive(false);
            levelMenuGO.SetActive(false);
            lostMenuGO.SetActive(false);
            winMenuGO.SetActive(false);
            pauseMenuGO.SetActive(false);
            InGameMenu.SetActive(false);

            if (menuGO != null)
            {
                menuGO.SetActive(true);
            }
        }
        public void StartGame()
        {
            GameStateManager.Instance.SetState(GameState.InGame);
            ShowMenu(InGameMenu);
            //Instantiate(ballPrefab,ballLocation,Quaternion.identity);
        }
        public void GameOver()
        {
            GameStateManager.Instance.SetState(GameState.Lost);
            ShowMenu(lostMenuGO);
        }
        public void WinGame()
        {
            GameStateManager.Instance.SetState(GameState.Win);
            ShowMenu(winMenuGO);
        }
        public void GoToPauseMenu()
        {
            GameStateManager.Instance.SetState(GameState.Pause);
            ShowMenu(pauseMenuGO);
        }
        public void GoToMainMenu()
        {
            GameStateManager.Instance.SetState(GameState.MainMenu);
            ShowMenu(mainMenuGO);
        }
        public void GoToLevelMenu()
        {
            GameStateManager.Instance.SetState(GameState.LevelMenu);
            ShowMenu(levelMenuGO);
        }
        public void GoToOptionsMenu()
        {
            GameStateManager.Instance.SetState(GameState.OptionsMenu);
            ShowMenu(optionsMenuGO);
        }
    }
}
