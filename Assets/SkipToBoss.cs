using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipToBoss : MonoBehaviour
{
    public Button bossButton;
    public int daysToShowButton;
    public int clickButtonCount = 0;
    private void OnEnable()
    {
        if(GameManager.Instance.dayCount >= daysToShowButton && clickButtonCount != 1 && GameManager.Instance.inBoss == false)
        {
            bossButton.interactable = true;
        }
        else
        {
            bossButton.interactable = false;
        }
    }
    public void GoToBoss()
    {
        GameManager.Instance.ShowBoss();
        this.GetComponent<StatisticsScript>().Close();
        clickButtonCount = 1;
        bossButton.interactable = false;
        GameManager.Instance.inBoss = true;
    }
}
