using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private PlayerComponent _player;
	[SerializeField] private ScoreCounter _scoreCounter;
	[SerializeField] private Canvas _uiCanvas;

	private bool _isLevelComplete = false;

	private void Awake()
	{
		_player.OnCollectCoin += CollectCoin;
		_player.OnFinishLineCrossed += CrossFinishLine;
	}

	private void CollectCoin(int value)
	{
		_scoreCounter.AddScore(value);
	}

	private void CrossFinishLine()
	{
		_isLevelComplete = true;
		_player.TurnOffInput();
		StartCoroutine(_player.FinishCoroutine());

		_uiCanvas.gameObject.SetActive(true);
	}
	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void OnDestroy()
	{
		_player.OnCollectCoin -= CollectCoin;
		_player.OnFinishLineCrossed -= CrossFinishLine;
	}
}
