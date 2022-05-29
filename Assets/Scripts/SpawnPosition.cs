using UnityEngine;

namespace Scripts
{
    public class SpawnPosition : MonoBehaviour
    {
        [SerializeField] private Color _positionColor;

        private void OnDrawGizmos()
        {
            Gizmos.color = _positionColor;
            Gizmos.DrawSphere(transform.position, 0.5f);
        }
    }
}