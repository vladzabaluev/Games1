using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;

    public float force = 40;
    public float power = 20;
    // Start is called before the first frame update
    void Start()
    {
      
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
            rb.AddForce(power * Vector2.Reflect(transform.position, Vector2.right));
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
