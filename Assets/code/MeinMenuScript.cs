using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeinMenuScript : MonoBehaviour
{
   public void ChangeScenes(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);   
    }
 public void Exit()
    {
        Application.Quit();
    }
}