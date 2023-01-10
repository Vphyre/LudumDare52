using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBanana : MonoBehaviour
{
    [SerializeField] private GameObject hideObj;
    public void Hide()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        hideObj.SetActive(false);
    }
    public void Show()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        hideObj.SetActive(true);
    }
}
