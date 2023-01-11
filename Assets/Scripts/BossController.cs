using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float bossAttackRangeInSeconds;
    public GameObject bulletPrefab;

    void Start()
    {
        InvokeRepeating("BossAttack", 0, bossAttackRangeInSeconds);
    }

    private void BossAttack()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = this.transform.position;

        if(GetComponent<BossDamage>().life <= 0)
        {
            CancelInvoke();
        }
    }
    private void OnDisable()
    {
        CancelInvoke();    
    }
}
