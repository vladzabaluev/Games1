using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
   Rigidbody2D rb;

    public float force = 40;
    public float power = 20;

    public Transform FPBallSpawner;
    public Transform SPBallSpawner;

    public Transform FPStartPoint;
    public Transform SPStartPoint;

    public GameObject Player1;
    public GameObject Player2;

    public GameObject theBall;

    public ParticleSystem GoalSygnal;

    public Check check;

    // Start is called before the first frame update
    void Start()
    {
        rb = theBall.GetComponent<Rigidbody2D>();
        goToStartPosition();
        whoseBall();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.AddForce(10 * Vector3.up * force);
        }
        if (collision.CompareTag("Wall"))
        {
            //rb.AddForce(power * Vector2.Reflect(transform.position, Vector2.right));
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
        if (collision.CompareTag("FirstPlayerBot"))
        {
            check.SecondPlayerScored();

            theBall.transform.position = FPBallSpawner.position;
            rb.velocity = new Vector2(0, 0);

            goToStartPosition();
        }
        else if (collision.CompareTag("SecondPlayerBot"))
        {
            check.FirstPlayerScored();
            theBall.transform.position = SPBallSpawner.position;
            rb.velocity = new Vector2(0, 0);

            goToStartPosition();          
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.AddForce(Vector3.up * force);
        }
    }

    void goToStartPosition()
    {
        Player1.transform.position = FPStartPoint.position;
        Player1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Player2.transform.position = SPStartPoint.position;
        Player2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    void whoseBall()
    {
        int whoseMove = Random.Range(1, 3);
        if (whoseMove == 1)
        {
            theBall.transform.position = FPBallSpawner.position;
        }
        else
        {
            theBall.transform.position = SPBallSpawner.position;
        }
    }
}
