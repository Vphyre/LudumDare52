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
            GameManager.Instance.LoadEnd("FinalStoryScene");
        }
        Debug.Log("Proximo Boss");
        bosses[index].SetActive(true);
        index++;
    }
}
