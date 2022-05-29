using System.Collections.Generic;
using Scripts.Pool;
using UnityEngine;

namespace Scripts
{
    public class CoinComponent : MonoBehaviour, IPoolObject<CoinPoolController,CoinComponent>
    {
        [SerializeField] private int _coinValue;
        [SerializeField] private List<ParticleSystem> _particles;
        [SerializeField] private Renderer _renderer;

        private bool _isCollected;

        public int CoinValue => _coinValue;

        public bool IsCollected => _isCollected;


        private void Awake()
        {
            DeactivateParticles();
            gameObject.SetActive(true);
        }

        private CoinPoolController _pool;

        public void CollectCoin()
        {
            _isCollected = true;
            ActivateParticles();
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
            DeactivateParticles();
            _renderer.enabled = true;
            _isCollected = false;
            if (_pool != null)
                _pool.ReturnPooledGameObject(this);
            else
                Destroy(gameObject);
        }

        private void ActivateParticles()
        {
            foreach (ParticleSystem particle in _particles)
            {
                particle.gameObject.SetActive(true);
            }
        }private void DeactivateParticles()
        {
            foreach (ParticleSystem particle in _particles)
            {
                particle.gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BackCollider")) RemoveObject();
        }
    }
}