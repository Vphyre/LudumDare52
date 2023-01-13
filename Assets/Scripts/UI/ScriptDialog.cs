using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptDialog : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    public DialogData dialogData;
    public AudioSource audioSource;

    public Text characterName;
    public Text dialogText;
    public Image characterImg;
    int curIndexDialog = 0;

    private void Start()
    {
        canvas.worldCamera = Camera.main;
    }
    private void UpdateScreenInfo()
    {
        if (dialogData.listDialogTexts.Count > 0)
        {
            characterName.text = dialogData.listCharacterNames[curIndexDialog];
            dialogText.text = dialogData.listDialogTexts[curIndexDialog];
            characterImg.sprite = dialogData.listCharacterImgs[curIndexDialog];
            if (audioSource)
            {
                audioSource.clip = dialogData.voiceToPlay[curIndexDialog];
                audioSource.Play();
            }
        }
    }

    void OnEnable()
    {
        if (PlayerPrefs.GetInt("NoDialog") > 0)
        {
            gameObject.SetActive(false);
            return;
        }
        GameManager.Instance.dialogTrigger = true;
        Time.timeScale = 0f;
        UpdateScreenInfo();
        MusicSystem.Instance.StopOtherMusic();
        MusicSystem.Instance.PlayeOtherMusic("NPC");
    }

    public void Next()
    {
        curIndexDialog++;

        if (curIndexDialog < dialogData.listDialogTexts.Count)
        {
            UpdateScreenInfo();
        }
        else
        {
            this.gameObject.SetActive(false);
            GameManager.Instance.dialogTrigger = false;
            Time.timeScale = 1f;
        }
    }
    private void OnDisable()
    {
        GameManager.Instance.dialogTrigger = false;
        Time.timeScale = 1f;
        if (MusicSystem.Instance.musicController.bossSongTrigger)
        {
            MusicSystem.Instance.StopOtherMusic();
            MusicSystem.Instance.PlayeOtherMusic("Boss");
            return;
        }
        if (MusicSystem.Instance.musicController.pathBossSongTrigger)
        {
            MusicSystem.Instance.StopOtherMusic();
            MusicSystem.Instance.PlayeOtherMusic("Path");
            return;
        }
        MusicSystem.Instance.StartMusic();
        MusicSystem.Instance.StopOtherMusic();

    }
}
