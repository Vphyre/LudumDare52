using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    //fun��o de game over
    public void GO()
    {
        obj.SetActive(true);
        Time.timeScale = 0f;
        MusicSystem.Instance.StopOtherMusic();
        MusicSystem.Instance.PlayeOtherMusic("Path");
    }
    public void reload()
    {
        SceneManager.LoadScene("Gameplay");
        Time.timeScale = 1f;
    }


}
