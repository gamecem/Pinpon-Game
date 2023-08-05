using TMPro;
using UnityEngine;

namespace GameAssets.Scripts.Level
{
    public class LevelHandler : MonoBehaviour
    {
        private static LevelHandler instance;
        public static LevelHandler Instance => instance;

        [SerializeField] private Level level;
        [SerializeField] private TMP_Text maxCollideText;
        [SerializeField] private TMP_Text levelText;
        
        private int maxCollideCount;
        private int ballInLevelCount;
        public int MaxCollideCount => maxCollideCount;
        public int BallInLevelCount => ballInLevelCount;
        private void Awake()
        {
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
        private void Start()
        {
            maxCollideText.text = "Desired Collision " + maxCollideCount;
            levelText.text = level.name;
        }
        
        
    }
}