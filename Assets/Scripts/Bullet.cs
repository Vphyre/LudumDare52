using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float Bulletspeed;
    [SerializeField]
    private float DestroyBulletTM;
    public string bulletName;
    public SpriteRenderer spriteRenderer;
    public int damage;
    public float timer = 0;
    void Start()
    {
        if (InventorySystem.Instance.selectedBullet)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            bulletName = InventorySystem.Instance.selectedBullet.bulletName;
            Bulletspeed = InventorySystem.Instance.selectedBullet.speed;
            spriteRenderer.sprite = InventorySystem.Instance.selectedBullet.projectileImage;
            damage = InventorySystem.Instance.selectedBullet.damage;
        }
    }

    private void OnEnable() {
      timer = 0;
      if (InventorySystem.Instance.selectedBullet)
        {
            bulletName = InventorySystem.Instance.selectedBullet.bulletName;
            Bulletspeed = InventorySystem.Instance.selectedBullet.speed;
            if(spriteRenderer) {
              spriteRenderer.sprite = InventorySystem.Instance.selectedBullet.projectileImage;
            }
            damage = InventorySystem.Instance.selectedBullet.damage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Bulletspeed * Time.deltaTime, Space.Self);
        timer += Time.deltaTime;
        if (timer >= DestroyBulletTM) {
          gameObject.SetActive(false);
        }
    }
}
