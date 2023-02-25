using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class NextScenes : MonoBehaviour
    {
        [SerializeField] private string _nextSceneName;
        [SerializeField] private GameObject _guidCanvas;
        private bool isStay;
        [SerializeField] private bool _isEnd; 
        private Player2DMovement _player;

        private void Start()
        {
            isStay = false;
            
        }

        public void OnTriggerStay2D(Collider2D col)
        {
            if (col.TryGetComponent(out _player))
            {
                isStay = true;
                if (_isEnd == true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SceneManager.LoadScene("EndScene");
                    }
                }
                if (_isEnd == false)
                {                isStay = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SceneController.instance.LoadNextScene(_nextSceneName);
                        Debug.Log("E Press");
                    }
                }

            }
        }
        public void OnTriggerExit2D(Collider2D col)
        {
            if (col.TryGetComponent(out _player))
            {
                isStay = false;
            }
        }

        private void Update()
        {
            if (isStay == true)
            {
                _guidCanvas.SetActive(true);
            }
            else
            {
                _guidCanvas.SetActive(false);
            }
        }
    }
}
