using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private PlayerComponent _player;
	[SerializeField] private ScoreCounter _scoreCounter;
	[SerializeField] private FinishLineComponent _finishLine;

	private bool _isLevelComplete = false;

	private void Awake()
	{
		_player.OnCollectCoin += CollectCoin;
		_finishLine.OnFinishLineCrossed += CrossFinishLine;
	}

	private void CollectCoin(int value)
	{
		_scoreCounter.AddScore(value);
	}

	private void CrossFinishLine()
	{
		_isLevelComplete = true;

		Debug.Log("Level Is Complete");
	}

	private void OnDestroy()
	{
		_player.OnCollectCoin -= CollectCoin;
		_finishLine.OnFinishLineCrossed -= CrossFinishLine;
	}
}
