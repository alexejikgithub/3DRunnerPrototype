using Scripts.Pool;
using UnityEngine;

namespace Scripts
{
    public class CoinComponent : MonoBehaviour, IPoolObject<CoinPoolController,CoinComponent>
    {
        [SerializeField] private int _coinValue;
        [SerializeField] private ParticleSystem _particles;
        [SerializeField] private Renderer _renderer;

        private bool _isCollected = false;

        public int CoinValue => _coinValue;

        public bool IsCollected => _isCollected;


        private void Awake()
        {
            _particles.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }

        private CoinPoolController _pool;

        public void CollectCoin()
        {
            _isCollected = true;
            _particles.gameObject.SetActive(true);
            _renderer.enabled = false;
        }

        public void SetPool(CoinPoolController pool)
        {
            _pool = pool;
        }

        public void RemoveObject()
        {
            StopAllCoroutines();
            gameObject.SetActive(true);
            _particles.gameObject.SetActive(false);
            _renderer.enabled = true;
            _isCollected = false;
            if (_pool != null)
                _pool.ReturnPooledGameObject(this);
            else
                Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BackCollider")) RemoveObject();
        }
    }
}