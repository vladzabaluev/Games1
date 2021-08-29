using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 100f;
    float movingDirection;
    public bool canJump = false;

    Rigidbody2D rb;
    Animator anim;

    public KeyCode leftButton;
    public KeyCode rightButton;
    public KeyCode jumpButton;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftButton))
        {
            movingDirection = -1;
        }
        else if (Input.GetKey(rightButton))
        {
            movingDirection = 1;
        }
        else
        {
            movingDirection = 0;
        }

        if (Input.GetKeyDown(jumpButton) && canJump)
        {
            Jump();
        }

        anim.SetFloat("isRun", Mathf.Abs(movingDirection));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movingDirection * speed *100* Time.fixedDeltaTime, rb.velocity.y);
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce * 10, ForceMode2D.Force);
        anim.SetBool("isJump", true);       
    }
}
