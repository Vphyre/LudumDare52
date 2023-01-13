using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public List<AudioClip> dayMusics;
    public List<AudioClip> nightMusics;
    private int nightIndex = 0;
    private int dayIndex = 0;
    public bool bossSongTrigger = false;
    public bool pathBossSongTrigger = false;
    void Start()
    {

    }
    public void SetDayMusic()
    {
        if (bossSongTrigger || pathBossSongTrigger)
            return;
        MusicSystem.Instance.StopMusic();
        MusicSystem.Instance.ChangeMusic(dayMusics[dayIndex]);
        MusicSystem.Instance.StartMusic();
        dayIndex++;

        if (dayIndex > dayMusics.Count - 1)
        {
            dayIndex = 0;
        }
    }
    public void SetNightMusic()
    {
        if (bossSongTrigger || pathBossSongTrigger)
            return;
        MusicSystem.Instance.StopMusic();
        MusicSystem.Instance.ChangeMusic(nightMusics[nightIndex]);
        MusicSystem.Instance.StartMusic();
        nightIndex++;

        if (nightIndex > dayMusics.Count - 1)
        {
            nightIndex = 0;
        }
    }

}
