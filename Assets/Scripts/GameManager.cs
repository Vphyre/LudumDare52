using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private SaveData _saveData;
    public SaveData SaveData { get => _saveData; }

    protected override void Awake()
    {
        base.Awake();
    }
}
