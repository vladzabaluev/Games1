using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainhero : Unit
{
      
   
        [SerializeField]
    
    private bool isGrounded = false;

    public int health;
    public int numberOfLives;

    public Image[] lives;

    public Sprite fullLive;
    public Sprite emptyLive;

    Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 7f, rb.velocity.y);
        Checkground();
        Flip();
      
    }

    void Update()
    {

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))

            
        {
            jump();
            anim.SetTrigger("Jump");

        }

        if (isGrounded && Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("isRunnig", false);
        }
        if (isGrounded && Input.GetAxis("Horizontal") != 0)
        {
            Flip();
            anim.SetBool("isRunnig", true);
        }
        if (health <1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        } 
    }
    
    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);

    }
    // переворот

    void jump()
    {
        rb.AddForce(transform.up * 14f, ForceMode2D.Impulse);
    }
    // прыжок

    private void Checkground()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2F);
        isGrounded = colliders.Length > 1;
       

    }
    // проверка на наличие земли 


    private void OnCollisionEnter2D(Collision2D helplz)
    {
        if (helplz.gameObject.tag == "pipka")
        {
            health--;
        }
        if (helplz.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("winMenu");
        }
    }
    void Reloadlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);

    }
     public override void ReceiveDamage()
    {
        health--;

        rb.velocity = Vector3.zero;
        rb.AddForce (transform.up * 6f, ForceMode2D.Impulse);

        // Debug.Log(health);

        if (health > numberOfLives)
        {
            health = numberOfLives;
        }

        for (int i = 0; i < lives.Length; i++)
        {
            if (i < health)
            {
                lives[i].sprite = fullLive;
            }
            else
            {
                lives[i].sprite = emptyLive;
            }

            if (i < numberOfLives)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }

        }
    }
 
   
       
}
    // урон
   


