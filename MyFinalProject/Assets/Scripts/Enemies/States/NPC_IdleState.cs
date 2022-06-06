using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_IdleState : MonoBehaviour, INPC_State
{
    public Transform patrolArea;
    private EnemiesTeam enemiesTeam;

    private float minX, minZ, maxX, maxZ;

    [SerializeField]
    private Vector3 targetSpot;

    public float Offset = 2.5f;

    private float waitTime;
    public float startWaitTime = 5;

    public bool ShootedByPlayer = false;
    // Start is called before the first frame update

    public INPC_State ChangeState(NPC_Controller NPC)
    {
        PatrolArea(NPC);
        if (PlayerApproached(NPC) || ShootedByPlayer)
        {
            enemiesTeam.SendOneEnemyDamaged();
            NPC.anim.SetBool("isAggressive", true);
            return NPC.aggressive;
        }
        else
        {
            return NPC.idle;
        }
    }

    private void Start()
    {
        //npsNavMesh = GetComponent<NavMeshAgent>();
        minX = patrolArea.position.x - patrolArea.localScale.x / 2;
        maxX = patrolArea.position.x + patrolArea.localScale.x / 2;
        minZ = patrolArea.position.z - patrolArea.localScale.z / 2;
        maxZ = patrolArea.position.z + patrolArea.localScale.z / 2;

        FindNewPoint();
        waitTime = startWaitTime;
        enemiesTeam = patrolArea.GetComponent<EnemiesTeam>();
        enemiesTeam.OneEnemyDamaged.AddListener(EnemyDamaged);
    }

    private void FindNewPoint()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        targetSpot = new Vector3(randomX, transform.position.y, randomZ);
    }

    private void PatrolArea(NPC_Controller NPC)
    {
        NPC.npcNavMesh.SetDestination(targetSpot);
        NPC.anim.SetBool("isMoving", true);

        if (Vector3.Distance(transform.position, targetSpot) < Offset)
        {
            NPC.anim.SetBool("isMoving", false);
            if (waitTime <= 0)
            {
                FindNewPoint();

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public void EnemyDamaged()
    {
        ShootedByPlayer = true;
    }

    private bool PlayerApproached(NPC_Controller NPC)
    {
        float distance = Vector3.Distance(transform.position, NPC.target.position);
        if (distance <= NPC.aggrRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}