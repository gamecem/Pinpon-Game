using UnityEngine;

public class BallGroundCollisionCounter : MonoBehaviour
{
    #region Consts
    private const string Ground = nameof(Ground);
    #endregion

    #region Variables
    private int groundCollisionCount;
    #endregion
    private void Start()
    {
        groundCollisionCount = 0;
    }

    public int GroundCollisionCount { get => groundCollisionCount; set => groundCollisionCount = value; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Ground))
        {
            GroundCollisionCount++;
            Debug.Log("Ground Collisions: " + GroundCollisionCount);
        }
    }

    public int GetGroundCollisionCount()
    {
        return GroundCollisionCount;
    }

    public void ResetGroundCollisionCount()
    {
        GroundCollisionCount = 0;
    }
}
