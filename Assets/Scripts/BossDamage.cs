using UnityEngine;
using System.Collections;

public class BossDamage : MonoBehaviour
{
    public int life;
    private BossManager bossManager;

    public bool takeDamage = false;
    public float damageTimer = 1f;
    public SpriteRenderer spriteRenderer;
    private Color defaultColor;
    private WaitForSeconds blinkTime = new WaitForSeconds(0.1f);
    private AudioSource audioSource;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bossManager = FindObjectOfType<BossManager>();   
        audioSource = GetComponent<AudioSource>();
        defaultColor = spriteRenderer.color;
    }

    private void Update() {
        if (takeDamage) {
            damageTimer -= Time.deltaTime;
        }
        if (damageTimer <= 0) {
            takeDamage = false;
            StopAllCoroutines();
            spriteRenderer.color = defaultColor;
        }
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Damage(collision.gameObject.GetComponent<Bullet>().damage);
        }
    }
    private void Damage(int dam)
    {
        life -= dam;
        takeDamage = true;
        damageTimer = 1f;
        if (audioSource) {
            audioSource.Play();
        }
        StartCoroutine("damageFeedback");
        if (life <= 0)
        {
            bossManager.NextBoss();
            this.gameObject.SetActive(false);
        }
    }
  private IEnumerator damageFeedback() {
    while(takeDamage) {
        spriteRenderer.color = Color.red;
        yield return blinkTime;
        spriteRenderer.color = defaultColor;
        yield return blinkTime;
     }
  }

}