using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    // vida
    [SerializeField]
    private int life;
    //chamando script do game over
    private GameOver Ds;

    public Text LifeTxt;

    void Start()
    {
        Ds = FindObjectOfType<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeTxt != null)
        {
            LifeTxt.text = life.ToString();
        }

        Vector3 v = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += v * speed * Time.deltaTime;

        if (life <= 0)
        {
            Ds.GO();
        }
    }
}
