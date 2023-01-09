using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class MusicSystem : Singleton<MusicSystem>
{
    public AudioSource audioSource;
    protected override void Awake()
    {
        IsPersistentBetweenScenes = true;
        base.Awake();
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeMusic (AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StopMusic () {
        audioSource.Stop();
    }

    public void StartMusic () {
        audioSource.Play();
    }
}
