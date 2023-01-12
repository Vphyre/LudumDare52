using UnityEngine;
using System.Collections;

public class CollectableItem : MonoBehaviour
{
    public Seed seed;
    public bool initialItem;
    public bool interactable = true;
    public AudioSource audioSource;
    private float clipLength;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        clipLength = audioSource.clip.length;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Player") && interactable) {
            InventorySystem.Instance.AddSeed(seed);
            interactable = false;
            audioSource.Play();
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine("PlayCollectAudio");
        }
    }

    private void OnDestroy() {
        StopAllCoroutines();
    }

    IEnumerator PlayCollectAudio () {
        yield return new WaitForSeconds(clipLength);
        DisableItem();
    }

    public void DisableItem()
    {
        if(initialItem)
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
