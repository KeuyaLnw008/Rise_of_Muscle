using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class ToNextLevel: MonoBehaviour
    {
        [SerializeField] private string _nextSceneName;

        private  Player2DStats _player;

        private void OnTriggerEnter2D(Collider2D col)
        {
            // check if we are colliding with the player
            if (col.TryGetComponent(out _player))
            {
                // load the next scene
                LoadingScreenController.instance.LoadNextScene(_nextSceneName);
            }
        }
    }
}