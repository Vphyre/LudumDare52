using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsScript : MonoBehaviour
{
    public Canvas canvas;
    public GameObject statusPanel;
    public GameObject weaponsPanel;
    public GameObject monstersPanel;

    // Start is called before the first frame update
    void Start()
    {
        HideElements();
        Status();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HideElements()
    {
        statusPanel.SetActive(false);
        weaponsPanel.SetActive(false);
        monstersPanel.SetActive(false);
    }

    public void Status()
    {
        HideElements();
        statusPanel.SetActive(true);
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
