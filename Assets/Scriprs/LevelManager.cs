using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private PlayerComponent _player;
	[SerializeField] private ScoreCounter _scoreCounter;

	private void Awake()
	{
		_player.OnCollectCoin += CollectCoin;
	}

	private void CollectCoin(int value)
	{
		_scoreCounter.AddScore(value);
	}

	private void OnDestroy()
	{
		_player.OnCollectCoin -= CollectCoin;
	}
}
