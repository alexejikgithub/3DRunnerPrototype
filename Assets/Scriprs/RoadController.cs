
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{

	[SerializeField] private RoadBlockComponent _frontBlock;
	[SerializeField] private List<RoadTypePool> _pools;
	[SerializeField] private ObjectPoolController _coinPool;
	[SerializeField] private RoadBlockType[] _roadSequance;


	private RoadBlockComponent _currentBlock;
	private ObjectPoolController _currentPool;

	private int _blockIndex;
	private void Awake()
	{
		_frontBlock.SetRoadPool(GetPoolByType(_frontBlock.Type));
		_frontBlock.SetCoins(_coinPool);
		float cameraFarClipping = Camera.main.farClipPlane;
		float length = 0f;

		while (cameraFarClipping > length)
		{
			if (_blockIndex >= _roadSequance.Length) break;

			SpawnNewBlock();
			length += _currentBlock.Length;


		}
	}


	public void SpawnNewBlock()
	{
		if (_blockIndex >= _roadSequance.Length) return;

		_currentPool = GetPoolByType(_roadSequance[_blockIndex]);
		_currentBlock = _currentPool.GetPooledGameObject().GetComponent<RoadBlockComponent>();
		_currentBlock.transform.position = _frontBlock.transform.position + new Vector3(0, 0, _currentBlock.Length);
		_currentBlock.gameObject.SetActive(true);
		_currentBlock.SetRoadPool(_currentPool);
		_currentBlock.SetCoins(_coinPool);
		_frontBlock = _currentBlock;
		_blockIndex++;


	}

	private ObjectPoolController GetPoolByType(RoadBlockType type)
	{
		foreach (RoadTypePool pool in _pools)
		{
			if (pool.Type == type)
			{
				return pool.Pool;

			}
		}
		return null;
	}

}
