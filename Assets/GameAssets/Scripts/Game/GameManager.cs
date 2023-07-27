using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public void StartGame()
        {
            // Logic to start the game, e.g., load a scene or set initial game state
            GameStateManager.Instance.SetState(GameState.InGame);
        }

        public void GameOver()
        {
            // Logic for game over, e.g., display a game over screen
            GameStateManager.Instance.SetState(GameState.Lost);
            lostMenuGO.SetActive(true);
        }

        public void WinGame()
        {
            // Logic for winning the game, e.g., display a victory screen
            GameStateManager.Instance.SetState(GameState.Win);
            winMenuGO.SetActive(true);
        }

        public void GoToMainMenu()
        {
            // Logic to go to the main menu, e.g., load the main menu scene
            GameStateManager.Instance.SetState(GameState.MainMenu);
            try
            {
                SceneManager.LoadScene(0);
            }
            catch(UnityException e) 
            {
                Debug.Log(e);
            }
            mainMenuGO.SetActive(true);
            levelMenuGO.SetActive(false);
            optionsMenuGO.SetActive(false);
        }

        public void GoToLevelMenu()
        {
            // Logic to go to the level menu, e.g., load the level menu scene
            GameStateManager.Instance.SetState(GameState.LevelMenu);
            levelMenuGO.SetActive(true);
            mainMenuGO.SetActive(false);
        }

        public void GoToOptionsMenu()
        {
            // Logic to go to the options menu, e.g., load the options menu scene
            GameStateManager.Instance.SetState(GameState.OptionsMenu);
            optionsMenuGO.SetActive(true);
            mainMenuGO.SetActive(false);
        }

        public void GoToPauseMenu()
        {
            // Logic to pause the game and show the pause menu
            GameStateManager.Instance.SetState(GameState.Pause);
            pauseMenuGO.SetActive(true);
        }
    }
}
