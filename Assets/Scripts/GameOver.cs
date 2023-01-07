using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    //função de game over
  public void GO()
    {
       obj.SetActive(true);
        Time.timeScale = 0f;
    }
    public void reload() 
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }


}
