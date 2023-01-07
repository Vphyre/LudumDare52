using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private float speed;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += v * speed * Time.deltaTime;
    }
 }
