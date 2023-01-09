using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tr;
    [SerializeField] private float ShootForce;
    [SerializeField]private float BulletDestroyTime;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        tr=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("TiroBoss", 1,0);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,BulletDestroyTime);
    
    }
    private void TiroBoss()
    {
        Vector3 direction = (tr.position - transform.position).normalized;
        rb.velocity = direction * ShootForce;   
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }
}
