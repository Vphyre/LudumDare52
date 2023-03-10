using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatisticsScript : MonoBehaviour
{
    public GameObject npcsPanel;
    public GameObject weaponsPanel;
    public GameObject monstersPanel;
    public GameObject controlsPanel;
    public GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        HideElements();
        NPCs();
    }
    private void OnEnable()
    {
        MusicSystem.Instance.StopOtherMusic();
        MusicSystem.Instance.PlayeOtherMusic("Pause Menu");
        GameManager.Instance.pauseGameAmount++;
    }
    private void OnDisable()
    {
        if(MusicSystem.Instance == null)
        {
            return;
        }
        if (MusicSystem.Instance.musicController.bossSongTrigger)
        {
            MusicSystem.Instance.StopOtherMusic();
            MusicSystem.Instance.PlayeOtherMusic("Boss");
            return;
        }
        if (MusicSystem.Instance.musicController.pathBossSongTrigger)
        {
            MusicSystem.Instance.StopOtherMusic();
            MusicSystem.Instance.PlayeOtherMusic("Path");
            return;
        }
        MusicSystem.Instance.StartMusic();
        MusicSystem.Instance.StopOtherMusic();
    }

    private void HideElements()
    {
        npcsPanel.SetActive(false);
        weaponsPanel.SetActive(false);
        monstersPanel.SetActive(false);
        controlsPanel.SetActive(false);
        menuPanel.SetActive(false);
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

    public void Controls()
    {
        HideElements();
        controlsPanel.SetActive(true);
    }

    public void Menu()
    {
        HideElements();
        menuPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MENU");
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
