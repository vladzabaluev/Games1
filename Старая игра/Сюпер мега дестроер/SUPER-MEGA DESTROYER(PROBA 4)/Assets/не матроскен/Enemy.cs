using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed ;
    public int positionOfPatrol;
    public Transform point;
    public float stoppingdistance;


    private float timeBTWshots;
    public float starttimeBTWshots;

    public GameObject projectile;
    private Transform player;
    private Animator anim;
    bool moveingRight;
    bool chill = false;
    bool angry = false;
    bool goBack = false;
   
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBTWshots = starttimeBTWshots;
        anim = GetComponent<Animator>();

    }

    
    void Update()
    {
       

        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry==false)
        {
            chill=true;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingdistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingdistance) 
        {
            goBack = true;
            angry = false;

        }

        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            GoBack();
        }
       


    }


    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            moveingRight = false;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight =true;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

       
      
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (transform.position.x > player.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);//поворот за героем

            if (timeBTWshots <= 0)// задержка в стрельбе,сама стрельба
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBTWshots = starttimeBTWshots;
            }
            else
            {
                timeBTWshots -= Time.deltaTime;
            }
        }
        if (transform.position.x < player.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);


            if (timeBTWshots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBTWshots = starttimeBTWshots;
            }
            else
            {
                timeBTWshots -= Time.deltaTime;
            }
        }
        
    }
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
       if (transform.position.x < point.position.x-positionOfPatrol)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
       
        if (transform.position.x > point.position.x+positionOfPatrol)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}

