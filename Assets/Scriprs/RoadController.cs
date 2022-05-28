using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{

    [SerializeField] private RoadBlockComponent _frontBlock;
    [SerializeField] private List<RoadTypePool> _pools;
    [SerializeField] private int _numberOfInitialBlocks;
    [SerializeField] private RoadBlockType[] _roadSequance;
    

    private RoadBlockComponent _currentBlock;
    private ObjectPoolController _currentPool;

    private int _blockIndex;
    private void Awake()
    {
        _frontBlock.SetPool(GetPoolByType(_frontBlock.Type));

        for (int i = 0; i < _numberOfInitialBlocks; i++)
        {
            SpawnNewBlock();
            _blockIndex++;
        }
    }

    [ContextMenu("tryspawn")]
    private void SpawnNewBlock()
	{
        _currentPool = GetPoolByType(_roadSequance[_blockIndex]);
        _currentBlock = _currentPool.GetPooledGameObject().GetComponent<RoadBlockComponent>();
        _currentBlock.transform.position = _frontBlock.transform.position + new Vector3(0, 0, _currentBlock.Length);
        _frontBlock = _currentBlock;

    }

    private ObjectPoolController GetPoolByType(RoadBlockType type)
	{
        foreach(RoadTypePool pool in _pools)
		{
            if(pool.Type == type)
			{
                return pool.Pool;

            }
		}
        return null;
	}
 
}
