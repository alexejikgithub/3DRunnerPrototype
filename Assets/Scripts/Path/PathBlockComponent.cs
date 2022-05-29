using System.Collections.Generic;
using Scripts.Pool;
using UnityEngine;

namespace Scripts.Path
{
    public enum PathBlockType
    {
        Empty,
        WithCoinsCenter,
        WithCoinsRight,
        WithCoinsLeft,
        CoinsEverywhere,
        Finish
    }

    public class PathBlockComponent : MonoBehaviour, IPoolObject<PathPoolController,PathBlockComponent>
    {
        [SerializeField] private float _length;
        [SerializeField] private PathBlockType _type;
        [SerializeField] private List<SpawnPosition> _positions;
        public float Length => _length;
        public PathBlockType Type => _type;


        private PathPoolController _pathPool;


        public void SetPool(PathPoolController pool)
        {
            _pathPool = pool;
        }

        public void SetCoins(CoinPoolController pool)
        {
            CoinComponent coin;
            foreach (var position in _positions)
            {
                coin = pool.GetPooledGameObject();
                coin.SetPool(pool);
                coin.transform.position = position.transform.position;
                coin.gameObject.SetActive(true);
            }
        }

        public void RemoveObject()
        {
            StopAllCoroutines();
            if (_pathPool != null)
                _pathPool.ReturnPooledGameObject(this);
            else
                Destroy(gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("BackCollider")) RemoveObject();
        }
    }
}