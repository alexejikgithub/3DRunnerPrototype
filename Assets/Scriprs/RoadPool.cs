using System;
using UnityEngine;

[Serializable]
public class RoadTypePool
{
	[SerializeField] private ObjectPoolController _pool;
	[SerializeField] private RoadBlockType _type;


	public ObjectPoolController Pool => _pool;
	public RoadBlockType Type => _type;
}
