using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour
{
    public Canvas canvas;
    public DataStory dataStory;
    public Image imgStory;
    public Text txtStory;
    private int curIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        canvas.worldCamera = Camera.main;
    }

    private void UpdateScreenInfo()
    {
        imgStory.sprite = dataStory.listStoryImages[curIndex];
        txtStory.text = dataStory.listStoryTexts[curIndex];
    }

    void OnEnable()
    {
        UpdateScreenInfo();
    }

    public void Next()
    {
        curIndex++;

        if (curIndex < dataStory.listStoryTexts.Count)
        {
            UpdateScreenInfo();
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
