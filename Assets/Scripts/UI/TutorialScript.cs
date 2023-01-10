using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial") > 0)
        {
            Close();
        }
        else
        {
            this.gameObject.SetActive(true);
            PlayerPrefs.SetInt("Tutorial", 1);
        }
    }
    public void Close()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
}
