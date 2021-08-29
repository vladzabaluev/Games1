using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed=5f;
    public Transform target;
  //  public GameObject player;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      //  player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    { 
       /* if (Vector2.Distance(transform.position,target.position)>3)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } */
        if (transform.position.x> target.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (transform.position.x < target.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
   
}
