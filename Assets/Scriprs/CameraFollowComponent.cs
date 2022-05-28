using System;
using UnityEngine;

public class CameraFollowComponent : MonoBehaviour
{
	[SerializeField] private Transform _target;

	[SerializeField] private Vector3 _offset;
	[SerializeField] private float _movementSpeed;


	private Vector3 _desiredZPosition;
	private Vector3 _desiredXPosition;
	

	private void LateUpdate()
	{
		_desiredZPosition = new Vector3(transform.position.x, transform.position.y, _target.position.z) + _offset;
		transform.position = _desiredZPosition;
		_desiredXPosition = new Vector3(_target.position.x, transform.position.y, transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, _desiredXPosition, _movementSpeed * Time.deltaTime);
	}
}


