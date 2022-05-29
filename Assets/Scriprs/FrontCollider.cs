using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FrontCollider : MonoBehaviour
{
	[SerializeField] private UnityEvent OnBlockOver;

	private PathBlockComponent _block;
	private void OnTriggerExit(Collider other)
	{
		_block = other.GetComponent<PathBlockComponent>();
		if (_block!=null)
		{
			OnBlockOver?.Invoke();
		}
	}
}
