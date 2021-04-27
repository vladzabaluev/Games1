using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage=3;

    public float speed=5f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 1.5F);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.name); 
        Terminator3000 bot3000 = collider.GetComponent<Terminator3000>();

        if (bot3000 != null)
        {
            bot3000.TakeDamage(damage);
        }
        Destroy(gameObject);
    }


}
