using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapone : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Bullet;

    private float TimeShot;
    public float StartTime;
    public int startBullets = 20;
    int currentBullets;
    int bulClip;
    int bulletsLeft = 0;

    [SerializeField]
    private Text BulCount;

    private void Start()
    {
        bulClip = startBullets;
        currentBullets = startBullets;

    }

    void Update()
    {
        if (TimeShot <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                TimeShot = StartTime;
                currentBullets--;
            }
        }
        else
        {
            TimeShot -= Time.deltaTime;
        }

        BulCount.text = currentBullets + " / " + bulletsLeft ;
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft > 0)
        {
            Reload();
        }

    }

    void Shoot()
    {
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
    }

    void Reload()
    {
        int reason = bulClip - currentBullets;
        if (bulletsLeft >= reason )
        {
            bulletsLeft -= reason;
            currentBullets = startBullets;
        }
        else
        {
            currentBullets += bulletsLeft;
            bulletsLeft = 0;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BullClip"))
        {
            bulletsLeft += bulClip;
            Destroy(collision.gameObject);
        }

        
        
    }
}
