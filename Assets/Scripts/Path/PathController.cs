using System.Collections.Generic;
using Scripts.Pool;
using UnityEngine;

namespace Scripts.Path
{
    public class PathController : MonoBehaviour
    {
        [SerializeField] private PathBlockComponent _frontBlock;
        [SerializeField] private List<PathTypePool> _pools;
        [SerializeField] private CoinPoolController _coinPool;
        [SerializeField] private PathBlockType[] _pathSequence;


        private PathBlockComponent _currentBlock;
        private PathPoolController _currentPool;

        private int _blockIndex;

        public PathBlockType[] PathSequence => _pathSequence;
        public List<PathTypePool> Pools => _pools;

        private void Awake()
        {
            _frontBlock.SetPool(GetPoolByType(_frontBlock.Type));
            _frontBlock.SetCoins(_coinPool);
            
            if (Camera.main is null) return;
            var cameraFarClipping = Camera.main.farClipPlane;
            var length = 0f;

            while (cameraFarClipping > length)
            {
                if (_blockIndex >= PathSequence.Length) break;

                SpawnNewBlock();
                length += _currentBlock.Length;
            }
        }


        public void SpawnNewBlock()
        {
            if (_blockIndex >= PathSequence.Length) return;

            _currentPool = GetPoolByType(PathSequence[_blockIndex]);
            _currentBlock = _currentPool.GetPooledGameObject();
            _currentBlock.transform.position = _frontBlock.transform.position + new Vector3(0, 0, _currentBlock.Length);
            _currentBlock.gameObject.SetActive(true);
            _currentBlock.SetPool(_currentPool);
            _currentBlock.SetCoins(_coinPool);
            _frontBlock = _currentBlock;
            _blockIndex++;
        }

        public PathPoolController GetPoolByType(PathBlockType type)
        {
            foreach (var pool in _pools)
                if (pool.Type == type)
                    return pool.Pool;
            return _pools[0].Pool;
        }
    }
}