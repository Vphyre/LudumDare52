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
    private SpriteRenderer sr;
    public Text LifeTxt;
    private Animator anim;

    void Start()
    {
        Ds = FindObjectOfType<GameOver>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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

        anim.SetFloat("Horizontal", v.x);
        anim.SetFloat("Vertical", v.y);
        anim.SetFloat("Speed", v.magnitude);
        if (v != Vector3.zero)
        {
            anim.SetFloat("HorizontalIdle", v.x);
            anim.SetFloat("VerticalIdle", v.y);
        }

        if(Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow))     
        { 
          sr.flipX= true;
          
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sr.flipX = false;

        }

        if (life <= 0)
        {
            Ds.GO();
        }
    }
}
