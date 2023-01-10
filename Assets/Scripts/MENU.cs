using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MENU : MonoBehaviour
{
    public Toggle toggle;
    private void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial") > 0)
        {
            toggle.isOn = false;

        }
        else
        {
            toggle.isOn = true;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ActiveTutorial()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("Tutorial", 0);
            Debug.Log("Sem Tutorial");
        }
        else
        {
            PlayerPrefs.SetInt("Tutorial", 1);
            Debug.Log("Com Tutorial");
        }
    }


}
