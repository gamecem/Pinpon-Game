using UnityEngine;

namespace GameAssets.Scripts.Level
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        public int totalLevels = 30; 

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        public int GetTotalLevels()
        {
            return totalLevels;
        }
    }
}
