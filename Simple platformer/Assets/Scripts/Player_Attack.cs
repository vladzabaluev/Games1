using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public float startTimeBtwAttack;
    float timeBtwAttack;

    public Transform attackPoint;
    public float attackRange = .5f;
    public LayerMask enemyLayers;

    public int damage = 40;

    bool canWeAttack = true;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canWeAttack) //attack
        {
            Attack();
            canWeAttack = !canWeAttack;
        }
    }

    private void FixedUpdate()
    {
        if (timeBtwAttack <= 0 && !canWeAttack)
        {
            canWeAttack = true;
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.fixedDeltaTime;

        }
    }

    void Attack()
    {
        anim.SetTrigger("isAttack");

        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
