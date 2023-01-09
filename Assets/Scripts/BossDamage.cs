using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    public int life;
    private BossManager bossManager;
    private void Start()
    {
        bossManager = FindObjectOfType<BossManager>();    
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
        if (life <= 0)
        {
            bossManager.NextBoss();
            this.gameObject.SetActive(false);
        }
    }
}
