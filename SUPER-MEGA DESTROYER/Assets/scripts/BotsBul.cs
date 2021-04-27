using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsBul : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb = GetComponent<Rigidbody2D>();

        if (transform.position.x > player.position.x)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        Destroy(gameObject, 2F);
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collider)
    {

        Destroy(gameObject);
    }

}
