using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "New Invetory Data")]
public class InventoryData : ScriptableObject
{
    [Header("Seeds")]
    [Min(0)]
    public int potatoSeeds;
    [Min(0)]
    public int carrotSeeds;
    [Min(0)]
    public int cornSeeds;
    [Header("Ammunition")]
    [Min(0)]
    public int potatoAmmo;
    [Min(0)]
    public int carrotAmmo;
    [Min(0)]
    public int cornAmmo;
    [Min(0)]
    public int greenBananaArmo;
    [Min(0)]
    public int yellowBananaArmo;

}
