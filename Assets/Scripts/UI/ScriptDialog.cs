using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptDialog : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    public DialogData dialogData;

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
    }
}
