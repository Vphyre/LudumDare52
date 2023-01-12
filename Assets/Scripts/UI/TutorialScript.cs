using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject npcDialog;
    private void Awake()
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
        if (PlayerPrefs.GetInt("NoDialog") > 0)
        {
            npcDialog.SetActive(false);
        }
        else
        {
            npcDialog.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
