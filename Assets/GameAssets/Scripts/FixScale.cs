using UnityEngine;

namespace GameAssets.Scripts
{
    public class FixScale: MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        private void Start()
        {
            rectTransform.transform.localScale = new Vector3(1, 1, 0);
        }
    }
}
