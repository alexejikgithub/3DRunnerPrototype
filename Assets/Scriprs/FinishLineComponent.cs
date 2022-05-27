using System;
using UnityEngine;

public class FinishLineComponent : MonoBehaviour
{
	public Action OnFinishLineCrossed;
	
	private void OnTriggerEnter(Collider other)
	{
		PlayerComponent player = other.gameObject.GetComponent<PlayerComponent>();
		if (player != null)
		{
			OnFinishLineCrossed?.Invoke();
		}
	}
}
