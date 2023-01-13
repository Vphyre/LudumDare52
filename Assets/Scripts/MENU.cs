using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MENU : MonoBehaviour
{
    public Toggle toggle;
    public Toggle dialogToggle;
    public Toggle tipsToggle;
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
        PlayerPrefs.SetInt("NoDialog", 0);
        PlayerPrefs.SetInt("Tips", 0);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame(string sceneName)
    {
        if(PlayerPrefs.GetInt("NoDialog") > 0)
        {
            SceneManager.LoadScene("Gameplay");
            return;
        }
        SceneManager.LoadScene(sceneName);
    }
    public void ActiveTutorial()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("Tutorial", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Tutorial", 1);
        }
    }
    public void ActiveDialogs()
    {
        if (dialogToggle.isOn)
        {
            PlayerPrefs.SetInt("NoDialog", 0);
        }
        else
        {
            PlayerPrefs.SetInt("NoDialog", 1);
        }
    }
        public void ActiveTips()
    {
        if (tipsToggle.isOn)
        {
            PlayerPrefs.SetInt("Tips", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Tips", 1);
        }
    }


}
