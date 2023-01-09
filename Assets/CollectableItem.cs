using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public Seed seed;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Player")) {
            InventorySystem.Instance.AddSeed(seed);
            Destroy(gameObject);
        }
    }
}
