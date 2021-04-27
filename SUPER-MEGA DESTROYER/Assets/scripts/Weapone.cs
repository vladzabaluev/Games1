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
    public int CurrentBul=30;
    public int AllBul=0;
    public int FullBul=120;

    [SerializeField]
    private Text BulCount;

    void Update()
    {
        if (TimeShot <= 0)
        {
            if (Input.GetButtonDown("Fire1") && CurrentBul>0)
            {
                Shoot();
                TimeShot = StartTime;
                CurrentBul -= 1;
            }
        }
        else
        {
            TimeShot -= Time.deltaTime;
        }

        BulCount.text = CurrentBul + " / " + AllBul;
        if (Input.GetKeyDown(KeyCode.R) && AllBul>0)
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
        int reason = 15 - CurrentBul;
        if (AllBul >= reason)
        {
            AllBul -= reason;
            CurrentBul = 15;
        }
        else
        {
            CurrentBul += AllBul;
            AllBul = 0;
        }
        
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BulClip>())
        {
            AllBul += 15;
            Destroy(collision.gameObject);
        }

        
        
    }
}
