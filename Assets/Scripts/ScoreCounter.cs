using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;

        private int _score;


        public void AddScore(int value)
        {
            _score += value;
            _scoreText.text = _score.ToString();
        }
    }
}