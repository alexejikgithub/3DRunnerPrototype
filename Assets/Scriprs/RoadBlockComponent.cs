using System.Collections.Generic;
using UnityEngine;


public enum RoadBlockType
{
	
	Empty,
	WithCoinsCenter,
	WithCoinsRight,
	WithCoinsLeft,
	CoinsEverywhere,
	Finish
}
public class RoadBlockComponent : MonoBehaviour, IPoolObject
{
	[SerializeField] private float _length;
	[SerializeField] private RoadBlockType _type;
	[SerializeField] private ObjectPoolController _coinPool;
	[SerializeField] private List<SpawnPosition> _positions;
	public float Length => _length;
	public RoadBlockType Type => _type;


	private ObjectPoolController _roadPool;
	



	public void SetRoadPool(ObjectPoolController pool)
	{
		_roadPool = pool;
	}

	public void SetCoins(ObjectPoolController pool)
	{
		_coinPool = pool;
		CoinComponent coin;
		foreach (SpawnPosition position in _positions)
		{
			coin = _coinPool.GetPooledGameObject().GetComponent<CoinComponent>();
			coin.SetRoadPool(_coinPool);
			coin.transform.position = position.transform.position;
			coin.gameObject.SetActive(true);
		}
	}

	public void RemoveObject()
	{
		StopAllCoroutines();
		if (_roadPool != null)
			_roadPool.ReturnPooledGameObject(gameObject);
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
