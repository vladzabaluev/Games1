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
    public float startWaitTime = 2;

    public bool ShootedByPlayer = false;
    // Start is called before the first frame update

    public INPS_State ChangeState(NPS_StateController npc)
    {
        PatrolArea(npc);
        if (PlayerApproached(npc) || TakeDamage(npc))
        {
            return npc.aggressive;
        }
        else
        {
            return npc.idle;
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
    }

    private void FindNewPoint()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        targetSpot = new Vector3(randomX, transform.position.y, randomZ);
    }

    private void PatrolArea(NPS_StateController npc)
    {
        npc.npsNavMesh.SetDestination(targetSpot);
        if (Vector3.Distance(transform.position, targetSpot) < Offset)
        {
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

    private bool TakeDamage(NPS_StateController npc)
    {
        return ShootedByPlayer;
        //сделать сообщение всем в области, область=слушатель?? а потом гаврики=слушатели
    }

    private bool PlayerApproached(NPS_StateController npc)
    {
        float distance = Vector3.Distance(transform.position, npc.target.position);
        if (distance <= npc.aggrRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}