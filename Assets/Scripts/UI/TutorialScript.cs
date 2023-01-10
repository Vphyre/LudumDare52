using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public void Close()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
}
