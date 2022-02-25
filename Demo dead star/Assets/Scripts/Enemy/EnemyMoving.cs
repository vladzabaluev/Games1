using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    Vector3 lookDirection;
    public float distanceToPlayer = 0.3f;
    RaycastHit hit;

    CloseCombatEnemy _combatEnemy;
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("/Player");
        _combatEnemy = GetComponent<CloseCombatEnemy>();
        _anim = transform.GetChild(2).GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {

        if (Physics.Raycast(transform.position, transform.forward, out hit) )
        {
            if (hit.transform.CompareTag("Player")) 
            {
                if (Vector3.Distance(transform.position, player.transform.position) > distanceToPlayer)
                {
                    agent.isStopped = false;
                    agent.SetDestination(player.transform.position);
                    _anim.SetBool("isAttack", false);
                }
                else
                {
                    agent.isStopped = true;
                    //_anim.SetBool("isAttack", false);
                    if (Time.time >= _combatEnemy.nextTimeAttack)
                    {
                        _combatEnemy.Attack();
                        //combatEnemy.nextTimeAttack = Time.time + 1 / combatEnemy.attackPerSecond;
                    }
                }

            }
            else
            {
                agent.isStopped = false;
                agent.SetDestination(player.transform.position);
            }
        }
            lookDirection = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(lookDirection);
    }

}
