using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public Canvas canvas;
    public void Close()
    {
        canvas.enabled = false;
    }
}
