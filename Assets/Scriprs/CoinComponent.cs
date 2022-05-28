using System.Collections;
using UnityEngine;

public class CoinComponent : MonoBehaviour
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

	public IEnumerator DestroyCoin()
	{
		_particles.gameObject.SetActive(true);
		_renderer.enabled = false;
		yield return new WaitForSeconds(_particlesTime);
		Destroy(gameObject);
	}

	
}
