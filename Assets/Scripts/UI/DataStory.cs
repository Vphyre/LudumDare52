using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataStory : ScriptableObject
{
    public List<Sprite> listStoryImages = new List<Sprite>();
    public List<string> listStoryTexts = new List<string>();
}
