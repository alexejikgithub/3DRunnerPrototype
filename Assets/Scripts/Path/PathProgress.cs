using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Path
{
    public class PathProgress : MonoBehaviour
    {
        [SerializeField] private PathController _path;
        [SerializeField] private PlayerComponent _player;
        [SerializeField] private Image _bar;

        private float _finishZ;
        private float _initialDistance;
        private float _percentLeft;


        private void Awake()
        {
            GetInitialValues();
        }

        private void LateUpdate()
        {
            CheckDistanceLeft();
        }

        private void GetInitialValues()
        {
            foreach (PathBlockType pathBlockType in _path.PathSequence)
            {
                if (pathBlockType == PathBlockType.Finish)
                {
                    continue;
                }

                _finishZ += _path.GetPoolByType(pathBlockType).PrefabToPool.Length;
            }
            _finishZ += _path.transform.position.z;
            _initialDistance = _finishZ - _player.transform.position.z;
        }

        private void CheckDistanceLeft()
        {
            _percentLeft = Mathf.Clamp((_finishZ - _player.transform.position.z) / _initialDistance, 0f, 1f);
            _bar.fillAmount = 1 - _percentLeft;
        }
    }
}