using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
	[SerializeField] private Text _scoreText;
	
	private int _score;


	public void AddScore(int value)
	{
		_score += value;
		_scoreText.text = "Score: " + _score.ToString();
		
	}
}