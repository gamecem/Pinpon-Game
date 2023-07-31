using UnityEngine;

namespace GameAssets.Scripts.Level
{
    public class LevelHandler : MonoBehaviour
    {
        private static LevelHandler instance;
        public static LevelHandler Instance => instance;

        [SerializeField] private Level level;
        private int maxCollideCount;
        private int ballInLevelCount;
        public int MaxCollideCount => maxCollideCount;
        public int BallInLevelCount => ballInLevelCount;

        private void Awake()
        {
            // Enforce the singleton pattern
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(this.gameObject); 

            maxCollideCount = level.MaxCollideCount;
            ballInLevelCount = level.BallInLevelCount;
        }
    }
}