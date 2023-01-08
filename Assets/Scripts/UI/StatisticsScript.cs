using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsScript : MonoBehaviour
{
    public Canvas canvas;
    public GameObject npcsPanel;
    public GameObject weaponsPanel;
    public GameObject monstersPanel;

    // Start is called before the first frame update
    void Start()
    {
        HideElements();
        NPCs();
    }

    private void HideElements()
    {
        npcsPanel.SetActive(false);
        weaponsPanel.SetActive(false);
        monstersPanel.SetActive(false);
    }

    public void NPCs()
    {
        HideElements();
        npcsPanel.SetActive(true);
    }

    public void Weapons()
    {
        HideElements();
        weaponsPanel.SetActive(true);
    }

    public void Monsters()
    {
        HideElements();
        monstersPanel.SetActive(true);
    }

    public void Close()
    {
        canvas.enabled = false;
    }
}
