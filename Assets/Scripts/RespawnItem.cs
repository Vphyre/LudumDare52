using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnItem : MonoBehaviour
{
    public void Respawn()
    {
        if (Random.Range(1, 10) > 6)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<CollectableItem>().interactable = true;
        }
    }
}
