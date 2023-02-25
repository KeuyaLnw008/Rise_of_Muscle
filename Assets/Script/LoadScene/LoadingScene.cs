using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
   [SerializeField] private GameObject SetActiveCredit;
   [SerializeField] private GameObject SetActiveMenu;
   public void Credit()
   {
      SetActiveCredit.SetActive(true);
      SetActiveMenu.SetActive(false);
   }
   public void Menu()
   {
      SetActiveMenu.SetActive(true);
      SetActiveCredit.SetActive(false);
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.gameObject.tag == "Player")
      {
         Destroy(GameObject.FindGameObjectWithTag("Dont"));
         SceneManager.LoadScene("Cutscene2");
      }
      
      
   }
   
}
