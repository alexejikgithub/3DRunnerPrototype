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
	}

	private ObjectPoolController _pool;

	public IEnumerator DestroyCoin()
	{
		_particles.gameObject.SetActive(true);
		_renderer.enabled = false;
		yield return new WaitForSeconds(_particlesTime);
		RemoveObject();
	}

	public void SetRoadPool(ObjectPoolController pool)
	{
		_pool = pool;
	}

	public void RemoveObject()
	{
		StopAllCoroutines();
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
