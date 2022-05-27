using UnityEngine;
using UnityEngine.Events;

public class DisableOnDistanceUtil : MonoBehaviour
{

	[SerializeField] private UnityEvent OnBecomeVisible;
	[SerializeField] private UnityEvent OnBecomeInisible;

	private void OnBecameInvisible()
	{
		OnBecomeInisible?.Invoke();
	}
	private void OnBecameVisible()
	{
		OnBecomeVisible?.Invoke();
	}
}
