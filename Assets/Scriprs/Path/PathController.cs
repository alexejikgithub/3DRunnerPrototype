
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

	public PathBlockType[] PathSequance => _pathSequance;
	public List<PathTypePool> Pools => _pools;

	private void Awake()
	{
		_frontBlock.SetPool(GetPoolByType(_frontBlock.Type));
		_frontBlock.SetCoins(_coinPool);
		float cameraFarClipping = Camera.main.farClipPlane;
		float length = 0f;

		while (cameraFarClipping > length)
		{
			if (_blockIndex >= PathSequance.Length) break;

			SpawnNewBlock();
			length += _currentBlock.Length;


		}
	}


	public void SpawnNewBlock()
	{
		if (_blockIndex >= PathSequance.Length) return;

		_currentPool = GetPoolByType(PathSequance[_blockIndex]);
		_currentBlock = _currentPool.GetPooledGameObject().GetComponent<PathBlockComponent>();
		_currentBlock.transform.position = _frontBlock.transform.position + new Vector3(0, 0, _currentBlock.Length);
		_currentBlock.gameObject.SetActive(true);
		_currentBlock.SetPool(_currentPool);
		_currentBlock.SetCoins(_coinPool);
		_frontBlock = _currentBlock;
		_blockIndex++;


	}

	public ObjectPoolController GetPoolByType(PathBlockType type)
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
