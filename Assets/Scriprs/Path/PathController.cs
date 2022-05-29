
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{

	[SerializeField] private PathBlockComponent _frontBlock;
	[SerializeField] private List<PathTypePool> _pools;
	[SerializeField] private ObjectPoolController _coinPool;
	[SerializeField] private PathBlockType[] _pathSequance;


	private PathBlockComponent _currentBlock;
	private ObjectPoolController _currentPool;

	private int _blockIndex;
	private void Awake()
	{
		_frontBlock.SetPool(GetPoolByType(_frontBlock.Type));
		_frontBlock.SetCoins(_coinPool);
		float cameraFarClipping = Camera.main.farClipPlane;
		float length = 0f;

		while (cameraFarClipping > length)
		{
			if (_blockIndex >= _pathSequance.Length) break;

			SpawnNewBlock();
			length += _currentBlock.Length;


		}
	}


	public void SpawnNewBlock()
	{
		if (_blockIndex >= _pathSequance.Length) return;

		_currentPool = GetPoolByType(_pathSequance[_blockIndex]);
		_currentBlock = _currentPool.GetPooledGameObject().GetComponent<PathBlockComponent>();
		_currentBlock.transform.position = _frontBlock.transform.position + new Vector3(0, 0, _currentBlock.Length);
		_currentBlock.gameObject.SetActive(true);
		_currentBlock.SetPool(_currentPool);
		_currentBlock.SetCoins(_coinPool);
		_frontBlock = _currentBlock;
		_blockIndex++;


	}

	private ObjectPoolController GetPoolByType(PathBlockType type)
	{
		foreach (PathTypePool pool in _pools)
		{
			if (pool.Type == type)
			{
				return pool.Pool;

			}
		}
		return null;
	}

}
