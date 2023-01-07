using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsScript : MonoBehaviour
{
    public Canvas canvas;
    public ScrollRect statusScrollView;
    public ScrollRect weaponsScrollView;
    public ScrollRect monstersScrollView;

    private Vector3 statusPosition;
    private Vector3 weaponsPosition;
    private Vector3 monstersPositon;

    // Start is called before the first frame update
    void Start()
    {
        statusPosition = statusScrollView.transform.position;
        weaponsPosition = weaponsScrollView.transform.position;
        monstersPositon = monstersScrollView.transform.position;

        HideElements();
        Status();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HideElements()
    {
        statusScrollView.enabled = false;
        weaponsScrollView.enabled = false;
        monstersScrollView.enabled = false;

        statusScrollView.transform.position = new Vector3(2000, 2000, 2000);
        weaponsScrollView.transform.position = new Vector3(2000, 2000, 2000);
        monstersScrollView.transform.position = new Vector3(2000, 2000, 2000);
    }

    public void Status()
    {
        HideElements();
        statusScrollView.enabled = true;
        statusScrollView.transform.position = statusPosition;
    }

    public void Weapons()
    {
        HideElements();
        weaponsScrollView.enabled = true;
        weaponsScrollView.transform.position = weaponsPosition;
    }

    public void Monsters()
    {
        HideElements();
        monstersScrollView.enabled = true;
        monstersScrollView.transform.position = monstersPositon;
    }

    public void Close()
    {
        canvas.enabled = false;
    }
}
