using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay = 2f;
    public float radius = 6f;
    public float power=500f;

    private float timeOfBoom;

    private Transform player;
    private Rigidbody2D playerRB;

    public GameObject boomEffect;
    bool isBoom = false;
    // Start is called before the first frame update
    void Start()
    {
        timeOfBoom = delay;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerRB = player.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(90, 180)) * Time.deltaTime);

        if (timeOfBoom <= 0 && isBoom == false)
        {
            KaBoom();
            isBoom = true;
        }
        else
        {
            timeOfBoom -= Time.deltaTime;
        }
    }

    private void KaBoom()
    {
        Instantiate(boomEffect, transform.position, transform.rotation);
       
        //if (Vector2.Distance(transform.position, player.position) <= radius)
        //{
         
        //    if (transform.position.x >= player.position.x)
        //    {
        //        // playerRB.AddForce(player.forward * power);
        //        playerRB.AddForce(new Vector2(-power, 5), ForceMode2D.Impulse);
        //    }
        //    if (transform.position.x <= player.position.x)
        //    {
        //        //  playerRB.AddForce(player.forward * power);
        //        playerRB.AddForce(new Vector2(power, 5), ForceMode2D.Impulse);
        //    }

        //}
        Destroy(gameObject);
   
    }

}

