using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipSystem : MonoBehaviour
{
    public TextMeshProUGUI tipText;
    public bool firstSeedTrigger = false;
    void Start()
    {
        if (PlayerPrefs.GetInt("Tips") > 0)
        {
            this.gameObject.SetActive(false);
            tipText.text = "";
            return;
        }
    }

    void Update()
    {
        NextTip();
    }
    public void NextTip()
    {
        if (GameManager.Instance.dayCount == 0)
        {
            if (InventorySystem.Instance.hasGreenBanana == false)
            {
                tipText.text = "Fish's tips: Pick up the Green Banana";
                return;
            }
            if ((InventorySystem.Instance.cornSeedQtd == 0 || InventorySystem.Instance.carrotSeedQtd == 0 || InventorySystem.Instance.potatoSeedQtd == 0))
            {
                tipText.text = "Fish's tips: Pick up and plant the seeds";

                if(firstSeedTrigger == false)
                {
                    return;
                }
            }
            else
            {
                firstSeedTrigger = true;
            }
            if(InventorySystem.Instance.plantAmount < 3)
            {
                tipText.text = "Fish's tips: Plant the seeds";
                return;
            }
            if (GameManager.Instance.pauseGameAmount == 0)
            {
                tipText.text = "Fish's tips: Press ESC to open the diary";
                return;
            }
            if (GameManager.Instance.pauseGameAmount == 1)
            {
                tipText.text = "Fish's tips: Skip to boss button will be available after day 1 (Esc)";
                return;
            }

            tipText.text = "Fish's tips: Look for new seeds, in the environment";
            return;
        }
        if (GameManager.Instance.dayCount == 1)
        {
            if (InventorySystem.Instance.cornSeedQtd > 0 && InventorySystem.Instance.carrotSeedQtd > 0 && InventorySystem.Instance.potatoSeedQtd > 0)
            {
                tipText.text = "Fish's tips: Plant the seeds";
                return;
            }
            else
            {
                tipText.text = "Fish's tips: Harvest your garden";
            }
        }
        if (GameManager.Instance.dayCount == 2)
        {
            tipText.text = "Fish's tips: Find and plant more potato seeds";
        }
        if (GameManager.Instance.dayCount == 3)
        {
            tipText.text = "Fish's tips: Find and plant more carrot seeds";
        }
        if (GameManager.Instance.dayCount == 4)
        {
            tipText.text = "Fish's tips: Find and plant more corn seeds";
        }
        if (GameManager.Instance.dayCount == 5)
        {
            tipText.text = "Fish's tips: Look for the forest ghost (easter egg)";
        }
        if (GameManager.Instance.dayCount == 6)
        {
            if (InventorySystem.Instance.hasGoldenBanana == false)
            {
                tipText.text = "Fish's tips: Solve the mystery of the nocturnal golden banana in the forest";
                return;
            }
            tipText.text = "Fish's tips: Remember to harvest the plants";
        }
        if (GameManager.Instance.dayCount == 7)
        {
            if (GameManager.Instance.inBoss == false)
            {
                tipText.text = "Fish's tips: Harvest the plants and prepare for the night";
                return;
            }
            tipText.text = "Fish's tips: Defeat the guardians using everything you've harvested";
        }
    }
}
