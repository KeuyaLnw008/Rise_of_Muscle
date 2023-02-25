using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class FruitPickup : MonoBehaviour
    {
        [SerializeField] private AddScoreEventChanel _eventChanel;
        [SerializeField] private int _scoreAmount = 1;

        private Player2DMovement _player;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out _player))
            {
                //ScoreManager.instance.AddScore(_scoreAmount);
                _eventChanel.RaiseEvent(_scoreAmount);
                Destroy(gameObject);
                //SoundManager.instance.Play(SoundManager.SoundName.Collect);
            }
        }
    }
}
