using System.Collections;
using UnityEngine;

public class CoinComponent : MonoBehaviour
{
	[SerializeField] private int _coinValue;
	[SerializeField] private ParticleSystem _particles;
	[SerializeField] private float _particlesTime;
	[SerializeField] private Renderer _renderer;
	private IEnumerator DestroyCoin()
	{
		_particles.gameObject.SetActive(true);
		_renderer.enabled = false;
		yield return new WaitForSeconds(_particlesTime);
		Destroy(gameObject);
	}


	private void OnTriggerEnter(Collider other)
	{
		PlayerComponent player = other.gameObject.GetComponent<PlayerComponent>();
		if(player!=null)
		{
			player.CollectCoin(_coinValue);
			StartCoroutine(DestroyCoin());
		}
	}
	
}
