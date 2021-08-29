using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper_Controller : MonoBehaviour
{

    public Healthbar hp;

    public float patrolDistance = 3;
    public float jumpForce = 40;
    public float speed=40;
    Vector3 targetPosition;
    bool thenLeft = false;


    public float jumpDelay = 1.5f;
    float timeBtwJump;

    Rigidbody2D rb;
    Animator anim;

    public bool canEnemyJump = false;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;

        timeBtwJump = jumpDelay;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == targetPosition.x && thenLeft)
        {
            targetPosition = new Vector3(transform.position.x + patrolDistance * 2, transform.position.y, transform.position.z);
            thenLeft = !thenLeft;

            transform.rotation = Quaternion.AngleAxis(0, Vector3.up); //flip the enemy in the direction of mooving

            hp.transform.rotation = Quaternion.AngleAxis(180, Vector3.up); //flip health bar, because we dont need flip it with enemy
        }
        else if (transform.position.x == targetPosition.x && !thenLeft)
        {
            targetPosition = new Vector3(transform.position.x - patrolDistance * 2, transform.position.y, transform.position.z);
            thenLeft = !thenLeft;

            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);//flip the enemy in the direction of mooving

            hp.transform.rotation = Quaternion.AngleAxis(180, Vector3.up); //flip health bar, because we dont need flip it with enemy
        }



        if (timeBtwJump <= 0 && canEnemyJump)
        {
            Jump();
            timeBtwJump = jumpDelay;
        }
        else if (timeBtwJump > 0) 
        {
            if(!canEnemyJump)
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
            timeBtwJump -= Time.deltaTime;
        }
            //Нужно чтобы во время прыжка время не считалось, движение во время прыжка
            //посмотреть что с координатами (возможно нужна будет проверка на больше или равно в том или ином случае)
            //добавить проверку на земле ли мы
    }


    void Jump()
    {
        rb.AddForce(transform.up * jumpForce);
        canEnemyJump = false;
        anim.SetBool("isJumped", true);
    }



    private void OnDrawGizmosSelected()
    {
        Vector3 line = new Vector3(2 * patrolDistance, 0, 0);
        Gizmos.DrawLine(transform.position - line, transform.position - line + Vector3.up * 2);
    }
}
