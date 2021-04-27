using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlameMovementR : MonoBehaviour
{
    public float speedx = 1f;
    public float speedy = 0.5f;

    public Transform Destroyer;

    public Transform FireResp;

    void Update()
    {
        transform.position = new Vector3(transform.position.x + speedx * Time.deltaTime, transform.position.y + speedy * Time.deltaTime, transform.position.z); // transform.position.y + speed * Time.deltaTime);//
        if (transform.position.x > Destroyer.position.x)
        {
            transform.position = FireResp.position;
        }
    }

}
