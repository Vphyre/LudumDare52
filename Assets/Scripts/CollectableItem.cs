using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public Seed seed;
    public bool initialItem;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Player")) {
            InventorySystem.Instance.AddSeed(seed);
            DisableItem();
        }
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
