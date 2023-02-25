using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void UpdateScore(int currentScore)
        {
            _scoreText.text = $"{currentScore}";
        }
    }
}
