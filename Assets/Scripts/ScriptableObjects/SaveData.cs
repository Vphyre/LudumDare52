using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "New Save Data")]
public class SaveData : ScriptableObject
{
    public int CurrentDayCicle;
    public InventoryData InventoryData;
}
