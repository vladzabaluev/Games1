using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminator3000 : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float positionOfPatrol;
    public float powerOfJump=7f;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public int health = 9;

    public GameObject BulEnemy;
    public Transform point;
    public Transform pointForBullet;

    public bool moveRight=true;
    bool calm = false;
    bool angry = false;
    bool strah = false;

    private Rigidbody2D rb;
    Transform player;

    [SerializeField]
    private Transform rightHand;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.queriesStartInColliders = false;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            calm = true;
        }
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            calm = false;
            strah = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            strah = true;
            angry = false;
        }

        if (calm == true)
        {
            Calm();
        }
        else if (angry == true)
        {
            Angry();
        }
        else  if (strah == true)
        {
            Ochkonul();
        }

        if (moveRight == true)
        {

           if (Physics2D.Linecast(transform.position, rightHand.position, 1 << LayerMask.NameToLayer("Wall")))

            {
            
                rb.velocity = new Vector2(rb.velocity.x, powerOfJump);
            }
        }
        else if (moveRight == false)
        {
            
            if (Physics2D.Linecast(transform.position, rightHand.position, 1 << LayerMask.NameToLayer("Wall")))
            {
                
                rb.velocity = new Vector2(rb.velocity.x, powerOfJump);
            }
        }

     

    }

    void Calm()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)//transform.position + positionOfPatrol))/
        {
            moveRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
       
        if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (moveRight)
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
            moveRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (transform.position.x < player.position.x)
        {
            moveRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (timeBtwShots <= 0)
        {
            Instantiate(BulEnemy, pointForBullet.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
    void Ochkonul()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            moveRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
