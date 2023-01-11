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
        InvokeRepeating("TiroBoss", 0,0);
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
            col.gameObject.GetComponent<Player>().life -= Random.Range(5, 15);
            Destroy(gameObject);
            return;
        }
        if (col.gameObject.CompareTag("bullet"))
        {
            col.gameObject.SetActive(false);
            Destroy(gameObject);
            return;
        }
        Destroy(gameObject);
    }
}
