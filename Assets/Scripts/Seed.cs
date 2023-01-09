using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Seed")]
public class Seed : ScriptableObject
{
    public int daysToGrow;
    public Sprite defaultSprite;
    public Sprite growUpSprite;
}
