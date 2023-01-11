using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public List<GameObject> bosses;
    private int index;
    private void Start()
    {
        index = 1;
    }
    public void FirstBoss()
    {
        bosses[0].SetActive(true);
    }
    public void NextBoss()
    {
        if (index == 3)
        {
            if (PlayerPrefs.GetInt("NoDialog") > 0)
            {
                GameManager.Instance.LoadEnd("CreditsScene");
                return;
            }
            GameManager.Instance.LoadEnd("FinalStoryScene");
            return;
        }
        bosses[index].SetActive(true);
        index++;
    }
}
