using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField]
    private float Bulletspeed;
    [SerializeField]
    private float DestroyBulletTM;
    [SerializeField]
    private bool stoopGr = false;
    [SerializeField]
    private GameObject explosion;
    void Start()
    {
        explosion.SetActive(false);
        Invoke("Stop", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (stoopGr == false)
        {
            transform.Translate(Vector2.right * Bulletspeed * Time.deltaTime, Space.Self);
        }
    }
    private void Explode()
    {
      explosion.SetActive(true);
        Destroy(gameObject,DestroyBulletTM);
    }
    private void Stop()
    {
        stoopGr = true;
        Invoke("Explode", 1f);
    }
}
