using UniRx;
using UnityEngine;

namespace GameAssets.Scripts.Game
{
    public enum GameState
    {
        MainMenu,
        InGame,
        Lost,
        Win,
        Pause,
        LevelMenu,
        OptionsMenu
    }

    public class GameStateManager : MonoBehaviour
    {
        private ReactiveProperty<GameState> currentState = new ReactiveProperty<GameState>(GameState.MainMenu);
        public IReadOnlyReactiveProperty<GameState> CurrentState => currentState;

        // Singleton instance
        private static GameStateManager instance;
        public static GameStateManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<GameStateManager>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject("GameStateManager");
                        instance = obj.AddComponent<GameStateManager>();
                    }
                }
                return instance;
            }
        }
        public void SetState(GameState newState)
        {
            currentState.Value = newState;
        }
    }
}