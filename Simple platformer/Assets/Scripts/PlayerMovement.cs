using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; //variable that responsible for the movement 
    float trafficSlide = 0f;

    public float powerJump = 10f;  //variable that responsible for the jump

    bool isRight = true;  //variable that responsible for the flip

    public bool canWeJump = false;

    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        trafficSlide = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(trafficSlide));

        if (Input.GetKeyDown(KeyCode.Space) && canWeJump) //jump
        {
            Jump();          
        }      

        if (trafficSlide > 0 && isRight == false) //flip
        {      
            Flip();
        }
        else if (trafficSlide < 0 && isRight == true)
        {           
            Flip();
        }

    }

    private void FixedUpdate()
    {      
        rb.velocity = new Vector2(speed * trafficSlide * Time.fixedDeltaTime * 10, rb.velocity.y);       
    }
    

    void Flip()
    {
        isRight = !isRight;
        if (isRight==true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
       
    }

    void Jump()
    {
        canWeJump = false;
        rb.AddForce(transform.up * powerJump * 10, ForceMode2D.Force) ;
        anim.SetBool("isJumped", true);
    }

    
}
