using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kubick : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed1 = 8f;
    public float speed2 = 5.5f;
    public float PowerOfJump = 12f;

    [SerializeField]
    private Transform checkground;

    public int scoreCount;
    public Text score;
    private float TimeScore;
    public float StartTime;

    bool isGrounded = false;

    public AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed1 * Time.deltaTime, transform.position.y);
        if (Physics2D.Linecast(transform.position, checkground.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }

        if (TimeScore<=0)
        {
            score.text = scoreCount + "";
            scoreCount += 1;
            TimeScore = StartTime;
        }
        else
        {
            TimeScore -= Time.deltaTime;        
        }
        if (scoreCount > 60)
        {
            transform.position = new Vector2(transform.position.x + speed2 * Time.deltaTime, transform.position.y);
        }
     
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, PowerOfJump);
        jumpSound.Play();
    }

}
