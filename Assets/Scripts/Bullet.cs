using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float Bulletspeed;
    [SerializeField]
    private float DestroyBulletTM;
    public string bulletName;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
      if (InventorySystem.Instance.selectedBullet) {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bulletName = InventorySystem.Instance.selectedBullet.bulletName;
        Bulletspeed = InventorySystem.Instance.selectedBullet.speed; 
        spriteRenderer.sprite = InventorySystem.Instance.selectedBullet.projectileImage;
      }
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector2.right * Bulletspeed * Time.deltaTime, Space.Self);
        
        Destroy(gameObject, DestroyBulletTM);
    } 
}
