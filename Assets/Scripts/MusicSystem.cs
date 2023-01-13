using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicSystem : Singleton<MusicSystem>
{
    public AudioSource audioSource;
    public AudioSource secundaryAudioSource;
    public MusicController musicController;
    public AudioClip NpcSong;
    public AudioClip pauseMenuSong;
    public AudioClip pathBossSong;
    public AudioClip bossSong;
    public AudioClip gameOverSong;
    protected override void Awake()
    {
        IsPersistentBetweenScenes = false;
        base.Awake();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
    public void PauseMusic()
    {
        audioSource.Pause();
    }
    public void StartMusic()
    {
        audioSource.Play();
    }
    public void ContinueMusic()
    {
        audioSource.UnPause();
    }

    public void PlayeOtherMusic(string otherMusic)
    {
        PauseMusic();
        if (otherMusic == "NPC")
        {
            secundaryAudioSource.clip = NpcSong;
        }
        else if (otherMusic == "Pause Menu")
        {
            secundaryAudioSource.clip = pauseMenuSong;
        }
        if (otherMusic == "Path")
        {
            secundaryAudioSource.clip = pathBossSong;
        }
        if (otherMusic == "Boss")
        {
            secundaryAudioSource.clip = bossSong;
        }
        if (otherMusic == "GameOver")
        {
            secundaryAudioSource.clip = gameOverSong;
        }
        secundaryAudioSource.Play();
    }
    public void PauseOtherMusic()
    {
        secundaryAudioSource.Pause();
    }
    public void ContinueOtherMusic()
    {
        secundaryAudioSource.UnPause();
    }
    public void StopOtherMusic()
    {
        secundaryAudioSource.Stop();
    }
}
