using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatLikeBullet : MonoBehaviour
{
    public float speed = 15;
    public float force = 350f;

    Rigidbody rb;

    Vector3 direction;

    Transform shootPoint;
    // Start is called before the first frame update
    void Start()
    {      
        rb = GetComponent<Rigidbody>();
        shootPoint = GameObject.Find("/Player/Feeder").transform;

    }

    public void Throw()
    {
        direction = (shootPoint.forward + Vector3.up)*2;
        rb.AddForce(direction * force, ForceMode.Impulse);

    }

}
