using System.Collections.Generic;
using UnityEngine;


public enum PathBlockType
{
	
	Empty,
	WithCoinsCenter,
	WithCoinsRight,
	WithCoinsLeft,
	CoinsEverywhere,
	Finish
}
public class PathBlockComponent : MonoBehaviour, IPoolObject
{
	[SerializeField] private float _length;
	[SerializeField] private PathBlockType _type;
	[SerializeField] private List<SpawnPosition> _positions;
	public float Length => _length;
	public PathBlockType Type => _type;


	private ObjectPoolController _pathPool;
	



	public void SetPool(ObjectPoolController pool)
	{
		_pathPool = pool;
	}

	public void SetCoins(ObjectPoolController pool)
	{
		CoinComponent coin;
		foreach (SpawnPosition position in _positions)
		{
			coin = pool.GetPooledGameObject().GetComponent<CoinComponent>();
			coin.SetPool(pool);
			coin.transform.position = position.transform.position;
			coin.gameObject.SetActive(true);
		}
	}

	public void RemoveObject()
	{
		StopAllCoroutines();
		if (_pathPool != null)
			_pathPool.ReturnPooledGameObject(gameObject);
		else
			Destroy(gameObject);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "BackCollider")
		{
			RemoveObject();
		}
	}
}
