using UnityEngine;

namespace GameAssets.Scripts.Level
{
    [CreateAssetMenu(menuName = "Level", fileName = "Level")]
    public class Level : ScriptableObject
    {
        [SerializeField] private int maxCollideCount;
        [SerializeField] private int ballInLevelCount;

        public int MaxCollideCount => maxCollideCount;

        public int BallInLevelCount => ballInLevelCount;
    }
}
