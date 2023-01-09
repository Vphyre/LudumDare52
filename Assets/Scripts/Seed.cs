using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Seed")]
public class Seed : ScriptableObject
{
    public string seedName;
    public int daysToGrow;
    public Sprite defaultSprite;
    public Sprite growUpSprite;
    public int bulletsPerPlant;
}
