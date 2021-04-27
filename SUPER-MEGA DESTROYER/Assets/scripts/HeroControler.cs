using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroControler : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    public float speed = 5f;
    public float PowerOfJump = 5f;

    private GameObject[] fire;

    [SerializeField]
    private Transform checkground;

    bool isGrounded;

    //
    void Start()
    {
        fire = GameObject.FindGameObjectsWithTag("Fire");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, checkground.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        Flip();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
            anim.SetTrigger("AreYouJump");
        }
       
        if (Input.GetAxis("Horizontal") == 0)
        {
           anim.SetBool("AreYouRunnig", false);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {         
           anim.SetBool("AreYouRunnig", true);
        }
    }
    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, PowerOfJump);
       
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Fire"))
        {
            Invoke(nameof(ReloadLevel), 0.2f);
        }

    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
