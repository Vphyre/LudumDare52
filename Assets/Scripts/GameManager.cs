using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int dayCount;
    [SerializeField] private SaveData _saveData;
    public SaveData SaveData { get => _saveData; }

    protected override void Awake()
    {
        IsPersistentBetweenScenes = true;
        base.Awake();
    }

    public void DayCicle () {
        dayCount++;
    }

    public void NightCicle() {
        //Check if day % 3 == 0 (3 days has pass)
        // Start boss battle if that is true.
        // Stop day night cicle on the boss battle
    }
}

