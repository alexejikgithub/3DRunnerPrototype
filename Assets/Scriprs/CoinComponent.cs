using System.Collections;
using UnityEngine;

public class CoinComponent : MonoBehaviour,IPoolObject
{
	[SerializeField] private int _coinValue;
	[SerializeField] private ParticleSystem _particles;
	[SerializeField] private float _particlesTime;
	[SerializeField] private Renderer _renderer;

	public int CoinValue => _coinValue;

	private void Awake()
	{
		_particles.gameObject.SetActive(false);
		gameObject.SetActive(true);
		
	}

	private ObjectPoolController _pool;

	public void CollectCoin()
	{
		_particles.gameObject.SetActive(true);
		_renderer.enabled = false;
	
	}

	public void SetPool(ObjectPoolController pool)
	{
		_pool = pool;
	}

	public void RemoveObject()
	{
		StopAllCoroutines();
		gameObject.SetActive(true);
		_renderer.enabled = true;
		if (_pool != null)
			_pool.ReturnPooledGameObject(gameObject);
		else
			Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "BackCollider")
		{
			RemoveObject();
		}
	}


}
