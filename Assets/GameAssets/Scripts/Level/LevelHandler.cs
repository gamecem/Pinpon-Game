
using UnityEngine;

namespace GameAssets.Scripts.Level
{
    public class LevelHandler : MonoBehaviour
    {
        [SerializeField] private Level level;
        private int maxCollideCount;
        private int ballInLevelCount;

        private void Start()
        {
            maxCollideCount = level.MaxCollideCount;
            ballInLevelCount = level.BallInLevelCount;
        }
        
        
        
        
        
    }
}
