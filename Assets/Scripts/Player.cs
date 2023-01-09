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
    public int life;
    //chamando script do game over
    private GameOver Ds;
    private Rigidbody2D rbp;
    private SpriteRenderer sr;
    public Text LifeTxt;
    private Animator anim;
    [Header("Danos dos chefes")]
    [Header("Chefe 1")]
    public int MinDamage1;
    [SerializeField] private int MaxDamage1;
    [Header("chefe 2")]
    public int MinDamage2;
    [SerializeField] private int MaxDamage2;
    [Header("chefe 3")]
    public int MinDamage3;
    [SerializeField] private int MaxDamage3;

    void Start()
    {
        Ds = FindObjectOfType<GameOver>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rbp= GetComponent<Rigidbody2D>();
        LifeTxt = GameObject.FindGameObjectWithTag("LifeText").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (LifeTxt != null)
        {
            LifeTxt.text = "LIFE: " + life.ToString();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss1"))
        {
            int damage = Random.Range(MinDamage1, MaxDamage1);
            life = life - damage;
            rbp.velocity = Vector2.zero;

        }
        if (collision.gameObject.CompareTag("Boss2"))
        {
            int damage = Random.Range(MinDamage2, MaxDamage2);
            life = life - damage;
            rbp.velocity = Vector2.zero;

        }
        if (collision.gameObject.CompareTag("Boss3"))
        {
            int damage = Random.Range(MinDamage3, MaxDamage3);
            life = life - damage;
            rbp.velocity = Vector2.zero;

        }
    }
}
