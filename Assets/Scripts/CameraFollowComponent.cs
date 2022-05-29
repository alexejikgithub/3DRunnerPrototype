using UnityEngine;

namespace Scripts
{
    /// <summary>
    /// Not used in this project and unfinished. Using Cinemachine  instead
    /// </summary>
    public class CameraFollowComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _movementSpeed;


        private Vector3 _desiredZPosition;
        private Vector3 _desiredXPosition;


        private void LateUpdate()
        {
            var transform1 = transform;
            var position = transform1.position;
            _desiredZPosition = new Vector3(position.x, position.y, _target.position.z) + _offset;
            position = _desiredZPosition;
            transform1.position = position;
        }
    }
}