using GameAssets.Scripts.Game;
using GameAssets.Scripts.Level;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Events;

namespace GameAssets.Scripts.Ball
{
    public class BallGroundCollisionCounter : MonoBehaviour
    {
        [System.Serializable]
        public class GroundCollisionEvent : UnityEvent<int> { }

        #region Consts
        private const string Ground = nameof(Ground);
        private const string WinBox = nameof(WinBox);
        private const string GameArea = nameof(GameArea);
        #endregion

        #region Reactive Variables
        private readonly ReactiveProperty<int> groundCollisionCount = new ReactiveProperty<int>(0);
        public IReadOnlyReactiveProperty<int> GroundCollisionCount => groundCollisionCount;
        #endregion

        [SerializeField] private GroundCollisionEvent onGroundCollision;

        private void Start()
        {
            groundCollisionCount.Value = 0;
            CountGroundCollision();
            HandleWinBoxCollision();
            HandleExitGameArea();
        }

        public void ResetGroundCollisionCount()
        {
            groundCollisionCount.Value = 0;
        }

        private void CountGroundCollision()
        {
            this.OnCollisionEnterAsObservable()
                .Where(collision => collision.gameObject.CompareTag(Ground))
                .Subscribe(_ =>
                {
                    groundCollisionCount.Value++;
                    Debug.Log("Ground Collisions: " + groundCollisionCount.Value);
    
                    onGroundCollision?.Invoke(groundCollisionCount.Value);
                    if (groundCollisionCount.Value > LevelHandler.Instance.MaxCollideCount)
                    {
                        GameManager.Instance.GameOver();
                    }
                })
                .AddTo(this);
        }

        private void HandleWinBoxCollision()
        {
            this.OnCollisionEnterAsObservable()
                .Where(collision => collision.gameObject.CompareTag(WinBox))
                .Subscribe(_ =>
                {
                    Debug.Log("You hit WinBox");
                    if (LevelHandler.Instance.MaxCollideCount == groundCollisionCount.Value)
                    {
                        GameManager.Instance.WinGame();
                    }
                    else
                    {
                        GameManager.Instance.GameOver();
                    }
                }).AddTo(gameObject);
        }

        private void HandleExitGameArea()
        {
            this.OnTriggerExitAsObservable()
                .Where(other => other.gameObject.CompareTag(GameArea))
                .Subscribe(_ =>
                {
                    GameManager.Instance.GameOver();
                }).AddTo(gameObject);
        }
    }
}