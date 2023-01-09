using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset;
    [SerializeField] private Transform GunPoint;
    [SerializeField] private GameObject projetil;
     private float time =0;
    [SerializeField] private float timebts;

    // Update is called once per frame
    void Update()
    {
        Mira();
        if (Time.time > time)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projetil, GunPoint.position, transform.rotation);
                time = Time.time + timebts;
            }
            
        }
    }

    private void Mira()
    {
        //rotação
        Vector3 dig = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dig.y, dig.x)* Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,angle);

        //posição
        Vector3 playermo = Camera.main.ScreenToWorldPoint(Input.mousePosition)- player.position;
        playermo.z= 0;
        transform.position = player.position+ (offset*playermo.normalized);

        //girar
        Vector3 scale = Vector3.one;
        if(angle>90|| angle < -90)
        {
            scale.y = -1;
        }
        else
        {
            scale.y = 1;
        }
        transform.localScale = scale;
    }
}
