using System;
using Scripts.Input;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
	[SerializeField] private float _runSpeed;
	[SerializeField] private float _horizontalSpeed;
	[SerializeField] private float _leftBorder;
	[SerializeField] private float _rightBorder;

	[SerializeField] private Animator _animator;
	[SerializeField] private InteractableCanvasObject _input;

	private bool _isRunning;
	private Rigidbody _rigidBody;

	private float _targetX;
	private static readonly int IsRunning = Animator.StringToHash("IsRunning");

	public Action<int> OnCollectCoin;
	public Action OnFinishLineCrossed;

	private float TargetX
	{
		get => _targetX;
		set
		{
			if (value >= _rightBorder)
			{
				_targetX = _rightBorder;
			}
			else if (value <= _leftBorder)
			{
				_targetX = _leftBorder;
			}
			else
			{
				{
					_targetX = value;
				}
			}
		}
	}

	private void Awake()
	{
		_rigidBody = GetComponent<Rigidbody>();

		_input.OnMouseDragEvent += OnDrag;
		_input.OnPointerDownEvent += OnPointerDown;
		_input.OnPointerUpEvent += OnPointerUp;
	}

	void FixedUpdate()
	{
		if(_isRunning)
		{
			transform.position = Vector3.MoveTowards(transform.position,
			new Vector3(TargetX, transform.position.y, transform.position.z), _horizontalSpeed * Time.deltaTime);
		}
		
	}


	private void OnPointerDown(Vector3 position)
	{
		StartRunning();
		TargetX = position.x;
	}

	private void OnDrag(Vector3 position)
	{
		TargetX = position.x;
	}

	private void OnPointerUp(Vector3 position)
	{
		StopRunning();
	}

	private void StartRunning()
	{
		_isRunning = true;
		_rigidBody.velocity = new Vector3(0, 0, _runSpeed);
		_animator.SetBool(IsRunning, _isRunning);
	}

	private void StopRunning()
	{
		_isRunning = false;
		_rigidBody.velocity = Vector3.zero;
		_animator.SetBool(IsRunning, _isRunning);
	}

	public void CollectCoin(int value)
	{
		OnCollectCoin?.Invoke(value);
	}
	

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(new Vector3(_leftBorder, 0.5f, 0), Vector3.forward * 10);
		Gizmos.DrawRay(new Vector3(_rightBorder, 0.5f, 0), Vector3.forward * 10);
	}

	private void OnTriggerEnter(Collider other)
	{
		CoinComponent coin = other.gameObject.GetComponent<CoinComponent>();
		if (coin != null)
		{
			
			CollectCoin(coin.CoinValue);
			StartCoroutine(coin.DestroyCoin());
			return;
		}

		FinishLineComponent finish = other.gameObject.GetComponent<FinishLineComponent>();
		if (finish != null)
		{
			OnFinishLineCrossed?.Invoke();
			return;
		}
	}

	private void OnDestroy()
	{
		_input.OnMouseDragEvent -= OnDrag;
		_input.OnPointerDownEvent -= OnPointerDown;
		_input.OnPointerUpEvent -= OnPointerUp;
	}
}