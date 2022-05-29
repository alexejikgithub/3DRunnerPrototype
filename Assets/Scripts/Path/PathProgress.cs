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
            for (var i = 0; i < _path.PathSequance.Length - 1; i++)
                _finishZ += _path.GetPoolByType(_path.PathSequance[i]).ObjectToPool.GetComponent<PathBlockComponent>()
                    .Length;
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