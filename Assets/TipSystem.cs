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
                tipText.text = "Fish's Tip: Pick up the Green Banana";
                return;
            }
            if ((InventorySystem.Instance.cornSeedQtd == 0 || InventorySystem.Instance.carrotSeedQtd == 0 || InventorySystem.Instance.potatoSeedQtd == 0))
            {
                tipText.text = "Fish's Tip: Pick up and plant the seeds";

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
                tipText.text = "Fish's Tip: Plant the seeds";
                return;
            }
            if (GameManager.Instance.pauseGameAmount == 0)
            {
                tipText.text = "Fish's Tip: Press ESC to read the diary";
                return;
            }
            if (GameManager.Instance.pauseGameAmount == 1)
            {
                tipText.text = "Tip: Skip to boss button will be available after day 1 (Esc)";
                return;
            }

            tipText.text = "Tip: Look for new seeds, in the environment";
            return;
        }
        if (GameManager.Instance.dayCount == 1)
        {
            if (InventorySystem.Instance.cornSeedQtd > 0 && InventorySystem.Instance.carrotSeedQtd > 0 && InventorySystem.Instance.potatoSeedQtd > 0)
            {
                tipText.text = "Tip: Plant the seeds";
                return;
            }
            else
            {
                tipText.text = "Tip: Harvest your garden";
            }
        }
        if (GameManager.Instance.dayCount == 2)
        {
            tipText.text = "Tip: Find and plant more potato seeds";
        }
        if (GameManager.Instance.dayCount == 3)
        {
            tipText.text = "Tip: Find and plant more carrot seeds";
        }
        if (GameManager.Instance.dayCount == 4)
        {
            tipText.text = "Tip: Find and plant more corn seeds";
        }
        if (GameManager.Instance.dayCount == 5)
        {
            tipText.text = "Tip: Look for the forest ghost (easter egg)";
        }
        if (GameManager.Instance.dayCount == 6)
        {
            if (InventorySystem.Instance.hasGoldenBanana == false)
            {
                tipText.text = "Solve the mystery of the nocturnal golden banana in the forest";
                return;
            }
            tipText.text = "Tip: Remember to harvest the plants";
        }
        if (GameManager.Instance.dayCount == 7)
        {
            if (GameManager.Instance.inBoss == false)
            {
                tipText.text = "Tip: Harvest the plants and prepare for the night";
                return;
            }
            tipText.text = "Defeat the guardians of legend using everything you've harvested";
        }
    }
}
