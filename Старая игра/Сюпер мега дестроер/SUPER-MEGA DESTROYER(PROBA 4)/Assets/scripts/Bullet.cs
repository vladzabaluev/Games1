using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 1.5F);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
      //  Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

}

