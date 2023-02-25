using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField]private string SceneName;
    
    public void Exit()
    {
        Application.Quit(); 
    }
    
    public void Loadscene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
