using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float Bulletspeed;
    [SerializeField]
    private float DestroyBulletTM;
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector2.up * Bulletspeed * Time.deltaTime, Space.Self);
        
        Destroy(gameObject, DestroyBulletTM);
    } 
}
