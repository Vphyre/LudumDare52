using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int dayCount;
    [SerializeField] private SaveData _saveData;
    public SaveData SaveData { get => _saveData; }
    public Light sun;
    public GameObject player;
    public Transform teleportPosition;
    public GameObject candleObject;
    public int daysToShowBoss;
    public bool inBoss = false;

    protected override void Awake()
    {
        IsPersistentBetweenScenes = false;
        base.Awake();
        Time.timeScale = 0f;
    }

    public void DayCicle()
    {
        dayCount++;
        sun.color = new Color32(255, 255, 255, 255);
    }

    public void NightCicle()
    {
        //Check if day % 3 == 0 (3 days has pass)
        // Start boss battle if that is true.
        // Stop day night cicle on the boss battle
        sun.color = new Color32(11, 12, 154, 255);
        VerifyBoss();
    }
    public void VerifyBoss()
    {
        if (dayCount == daysToShowBoss && inBoss == false)
        {
            ShowBoss();
        }
    }
    public void LoadEnd(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ShowBoss()
    {
        candleObject.SetActive(true);
        player.transform.position = teleportPosition.position;
        inBoss = true;
    }
}

