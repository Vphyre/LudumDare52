using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int life;
   
    

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += v * speed * Time.deltaTime;
    }

    public void TestingDay() {
        Debug.Log("Event works day executed!");
    }

    public void TestingNight() {
        Debug.Log("Event working, night executed");
    }
 }
