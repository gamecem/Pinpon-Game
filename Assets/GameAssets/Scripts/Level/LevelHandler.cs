
using UnityEngine;

namespace GameAssets.Scripts.Level
{
    public class LevelHandler : MonoBehaviour
    {
        [SerializeField] private Level level;
        private int maxCollideCount;
        private int ballInLevelCount;

        [SerializeField] private GameObject dieMenuGO;
        [SerializeField] private GameObject winMenuGO;
        
        private void Start()
        {
            maxCollideCount = level.MaxCollideCount;
            ballInLevelCount = level.BallInLevelCount;
        }
        
        
        
        
    }
}
