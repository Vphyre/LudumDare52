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
            MusicSystem.Instance.musicController.SetDayMusic();
            Time.timeScale = 1f;
            Close();
            // MusicSystem.Instance.PauseMusic();
        }
        else
        {
            Time.timeScale = 0f;
            GameManager.Instance.dialogTrigger = true;
            this.gameObject.SetActive(true);
            PlayerPrefs.SetInt("Tutorial", 1);
            MusicSystem.Instance.musicController.SetDayMusic();
            MusicSystem.Instance.PauseMusic();
        }
    }
    public void Close()
    {
        Time.timeScale = 1f;
        if (PlayerPrefs.GetInt("NoDialog") > 0)
        {
            GameManager.Instance.dialogTrigger = false;
            npcDialog.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            npcDialog.SetActive(true);
        }
        MusicSystem.Instance.StartMusic();
        this.gameObject.SetActive(false);
    }
}
