using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLock : MonoBehaviour
{
    public GameObject lockObject;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            lockObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
