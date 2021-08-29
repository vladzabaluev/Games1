using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    public Transform shotPoint;

    public GameObject bullet;
    public float APS = 2f; //attack per second
    float nextShotTime;

    Animator anim;

    public float angryTime = 2f;
    float normalTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextShotTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                nextShotTime = Time.time + 1 / APS;
            }

        }
        if (normalTime <= 0)
        {
            normalTime = angryTime;
            anim.SetBool("isShooting", false);
        }
        else
        {
            normalTime -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        anim.SetBool("isShooting", true);
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
    }

}
