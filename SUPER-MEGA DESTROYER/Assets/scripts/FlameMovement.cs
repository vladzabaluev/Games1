using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlameMovement : MonoBehaviour
{
    public float speedx = 1f;
    public float speedy = 0.5f;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Spawner"))
        {
            collision.GetComponent<FireSpawner>().CreateFire();
        }

    }


    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + speedx * Time.fixedDeltaTime,
            transform.position.y + speedy * Time.fixedDeltaTime, 0);
    }

}
