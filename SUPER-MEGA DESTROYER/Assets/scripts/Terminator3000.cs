using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminator3000 : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float positionOfPatrol;
    public float powerOfJump = 7f;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public int health = 9;

    public GameObject BulEnemy;
    //Transform point;

    float startX;
    public Transform pointForBullet;

    public bool moveRight = true;
    bool calm = false;
    bool angry = false;
    bool strah = false;

    private Rigidbody2D rb;
    Transform player;

    [SerializeField]
    private Transform rightHand;

    int playerMask;
    public float attackRange = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMask = LayerMask.NameToLayer("Player");

        Physics2D.queriesStartInColliders = false;
        timeBtwShots = startTimeBtwShots;

        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(pointForBullet.position, pointForBullet.right, attackRange);

        if (hit)
        {
            HeroControler hero = hit.transform.GetComponent<HeroControler>();
            if (hero != null)
            {
                Debug.Log("Hero");
                calm = false;
                angry = true;
                strah = false;
            }
        }

        if (transform.position.x - startX < positionOfPatrol && !angry)
        {
            calm = true;
            angry = false;
            strah = false;
        }
        //if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        //{

        //    angry = true;
        //    calm = false;
        //    strah = false;
        //}
        //else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        //{
        //    strah = true;
        //    angry = false;
        //}

        if (calm == true)
        {
            Calm();
        }
        else if (angry == true)
        {
            Angry();
        }
        //else if (strah == true)
        //{
        //    Ochkonul();
        //}

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

        if (transform.position.x > startX + positionOfPatrol)
        {
            moveRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.position.x < startX - positionOfPatrol)
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
    //void Ochkonul()
    //{

    //    transform.position = Vector2.MoveTowards(transform.position, new Vector2(startX, transform.position.y), speed * Time.deltaTime);

    //    if (transform.position.x < startX - positionOfPatrol)
    //    {
    //        moveRight = true;
    //        transform.localRotation = Quaternion.Euler(0, 0, 0);
    //    }

    //    if (transform.position.x > startX + positionOfPatrol)
    //    {
    //        moveRight = false;
    //        transform.localRotation = Quaternion.Euler(0, 180, 0);
    //    }
    //}
    public void TakeDamage(int damage)
    {
        angry = true;
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pointForBullet.position, new Vector3(pointForBullet.position.x + attackRange, pointForBullet.position.y, pointForBullet.position.z));
    }

}
