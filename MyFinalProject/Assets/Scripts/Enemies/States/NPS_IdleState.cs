using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPS_IdleState : MonoBehaviour, INPS_State
{
    public Transform patrolArea;
    private float minX, minZ, maxX, maxZ;

    [SerializeField]
    private Vector3 targetSpot;

    public float Offset = 2.5f;

    private float waitTime;
    public float startWaitTime = 5;

    public bool ShootedByPlayer = false;
    // Start is called before the first frame update

    public INPS_State ChangeState(NPS_StateController NPC)
    {
        PatrolArea(NPC);
        if (PlayerApproached(NPC) || TakeDamage(NPC))
        {
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
    }

    private void FindNewPoint()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        targetSpot = new Vector3(randomX, transform.position.y, randomZ);
    }

    private void PatrolArea(NPS_StateController NPC)
    {
        NPC.npsNavMesh.SetDestination(targetSpot);
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

    private bool TakeDamage(NPS_StateController NPC)
    {
        return ShootedByPlayer;
        //сделать сообщение всем в области, область=слушатель?? а потом гаврики=слушатели
    }

    private bool PlayerApproached(NPS_StateController NPC)
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