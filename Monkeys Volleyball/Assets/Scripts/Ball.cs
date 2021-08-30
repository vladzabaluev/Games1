using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   Rigidbody2D rb;

    public float force = 40;
    public float power = 20;

    int scoreFP = 0; //first player
    int scoreSP = 0; //second player

    public Transform FPBallSpawner;
    public Transform SPBallSpawner;
    public GameObject theBall;
    public GameObject createdBall;
    // Start is called before the first frame update
    void Start()
    {
        rb = theBall.GetComponent<Rigidbody2D>();
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
           // theBall.GetComponent<Rigidbody2D>().AddForce(10 * Vector3.up * force);
        }
        if (collision.CompareTag("Wall"))
        {
            rb.AddForce(power * Vector2.Reflect(transform.position, Vector2.right));
        }       
        if (collision.CompareTag("FirstPlayerBot"))
        {
            Debug.Log(++scoreSP);
            Destroy(theBall);
            Instantiate(theBall, FPBallSpawner.position, Quaternion.identity);
        }
        else if (collision.CompareTag("SecondPlayerBot"))
        {
            Debug.Log(++scoreFP);
            Destroy(theBall);
            Instantiate(theBall, SPBallSpawner.position, Quaternion.identity);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.AddForce(Vector3.up * force);
        }
        if (collision.CompareTag("Wall"))
        {
            rb.AddForce(power * Vector2.Reflect(transform.position, Vector2.right));
        }
    }
}
