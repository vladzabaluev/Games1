using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maiherobluat : Unit
{
    [SerializeField]
    private int lives = 3;
    private bool isGrounded = false;
    private Bullet bullet;
    


    private CharState State
    {
        get { return (CharState)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }

    Rigidbody2D rb;
    Animator anim;
    private SpriteRenderer sprite;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 7f, rb.velocity.y);
        Checkground();
        Flip();

    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shoot();
        if (Input.GetKeyDown(KeyCode.F)) Shoot();
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump();


        }

        if (isGrounded && Input.GetAxis("Horizontal") == 0)
        {
            anim.SetInteger("State", 0);
        }
        if (isGrounded && Input.GetAxis("Horizontal") != 0)
        {
            Flip();
            anim.SetInteger("State", 1);
        }

    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);

    }
  
    void jump()
    { 
        rb.AddForce(transform.up * 12f, ForceMode2D.Impulse);       
    }

    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 0.8F;
        Instantiate(bullet, position, bullet.transform.rotation);

        //newBullet.Parent = gameObject;
        // newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);

    }
    private void Checkground()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2F);
        isGrounded = colliders.Length > 1;
        if (!isGrounded) State = CharState.Jump;
        
    }
    
   
   

}
public enum CharState
{
    hold,
    Run,
    Jump,
    attack,
    dead
}
