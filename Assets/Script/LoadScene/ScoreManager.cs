using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyPlatformer
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        private int _score;
        [SerializeField] AddScoreEventChanel _addScoreEventChanel;
        [SerializeField] private UnityEvent<int> onScoreUpdated;

        private void OnEnable()
        {
            _addScoreEventChanel.AddListener(AddScore);
        }

        private void OnDisable()
        {
            _addScoreEventChanel.RemoveListener(AddScore);
        }

        public void AddScore(int increment)
        {
            _score += increment;
            onScoreUpdated?.Invoke(_score);
        }
    }
}

