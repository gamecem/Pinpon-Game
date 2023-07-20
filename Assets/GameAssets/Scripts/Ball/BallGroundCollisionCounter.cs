using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class BallGroundCollisionCounter : MonoBehaviour
{
    #region Consts
    private const string Ground = nameof(Ground);
    #endregion

    #region Reactive Variables
    private ReactiveProperty<int> groundCollisionCount = new ReactiveProperty<int>(0);
    public IReadOnlyReactiveProperty<int> GroundCollisionCount => groundCollisionCount;
    #endregion

    private void Start()
    {
        groundCollisionCount.Value = 0;

        this.OnCollisionEnterAsObservable()
            .Where(collision => collision.gameObject.CompareTag(Ground))
            .Subscribe(_ =>
            {
                groundCollisionCount.Value++;
                Debug.Log("Ground Collisions: " + groundCollisionCount.Value);
            })
            .AddTo(this);
    }
    public void ResetGroundCollisionCount()
    {
        groundCollisionCount.Value = 0;
    }
}
