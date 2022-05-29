using UnityEngine;
using UnityEngine.Events;

public class PlayerCollider : MonoBehaviour
{
	[SerializeField] private UnityEvent<CoinComponent> OnCoinTrigger;
	[SerializeField] private UnityEvent OnCrossFinish;

	
	private void OnTriggerEnter(Collider other)
	{
		CoinComponent coin = other.GetComponent<CoinComponent>();
		if (coin != null)
		{
			OnCoinTrigger?.Invoke(coin);
			return;
		}

		FinishLineComponent finish = other.gameObject.GetComponent<FinishLineComponent>();
		if (finish != null)
		{
			OnCrossFinish?.Invoke();
			return;
		}
	}
}
