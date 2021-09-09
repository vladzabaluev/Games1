using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage=3;

    public float speed=5f;
    Rigidbody2D rb;

    public float timeBeforeDestroy = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, timeBeforeDestroy);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Terminator3000 bot3000 = collider.GetComponent<Terminator3000>();

            bot3000.TakeDamage(damage);
        }

        Destroy(gameObject);
    }


}
