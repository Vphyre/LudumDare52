using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StoryScript : MonoBehaviour
{
    public Canvas canvas;
    public DataStory dataStory;
    public Image imgStory;
    public TextMeshProUGUI txtStory;

    public string sceneName = "";
    private int curIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        canvas.worldCamera = Camera.main;
    }

    private void UpdateScreenInfo()
    {
        if (dataStory.listStoryTexts.Count > 0)
        {
            imgStory.sprite = dataStory.listStoryImages[curIndex];
            txtStory.text = dataStory.listStoryTexts[curIndex];
        }
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
            if (sceneName != "") 
            {
                SceneManager.LoadScene(sceneName);
            }

            this.gameObject.SetActive(false);
        }
    }
}
