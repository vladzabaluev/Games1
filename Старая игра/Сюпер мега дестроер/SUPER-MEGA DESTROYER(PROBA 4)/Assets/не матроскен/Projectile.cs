using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float speed=27f;
    Rigidbody2D rb;

   
    
    private Transform player;
    private Vector2 target;
   



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
      
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


     void Update()
     {
      

        if (transform.position.x == target.x && transform.position.y== target.y)
         {
             DestroyProjectile();

         }

     }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
        Unit unit = other.GetComponent<Unit>();

        if (unit && unit is mainhero)
        {
            unit.ReceiveDamage();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    } 
} 
