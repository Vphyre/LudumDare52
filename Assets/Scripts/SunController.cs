using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    public Light _light;
    public void TurnDay()
    {
        _light.color = new Color32(255, 255, 255, 255);
    }
    public void TurnNight()
    {
        _light.color = new Color32(11, 12, 154, 255);
    }
}
