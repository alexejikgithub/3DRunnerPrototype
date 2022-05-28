using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FrontCollider : MonoBehaviour
{
	[SerializeField] private UnityEvent OnBlockOver;

	private RoadBlockComponent _block;
	private void OnTriggerExit(Collider other)
	{
		_block = other.GetComponent<RoadBlockComponent>();
		if (_block!=null)
		{
			OnBlockOver?.Invoke();
		}
	}
}
