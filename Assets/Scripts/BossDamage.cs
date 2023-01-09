using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    [SerializeField] private int life;
    [Header("dano da bala do player")]
    [SerializeField] private int DamageMin;
    [SerializeField] private int DamageMax;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            int dam = Random.Range(DamageMin, DamageMax);
            life -= dam; 

        }
    }
}
