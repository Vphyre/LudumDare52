using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLock : MonoBehaviour
{
    public GameObject lockObject;
    private BossManager bossManager;
    private void Start()
    {
        bossManager = FindObjectOfType<BossManager>(); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            MusicSystem.Instance.musicController.pathBossSongTrigger = false;
            MusicSystem.Instance.musicController.bossSongTrigger = true;
            MusicSystem.Instance.StopOtherMusic();
            MusicSystem.Instance.PlayeOtherMusic("Boss");
            lockObject.SetActive(true);
            this.gameObject.SetActive(false);
            bossManager.FirstBoss();
        }
    }
}
