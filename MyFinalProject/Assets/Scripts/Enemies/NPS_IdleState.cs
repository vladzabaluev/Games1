using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPS_IdleState : MonoBehaviour, INPS_State
{
    private NavMeshAgent npsNavMesh;

    public Transform patrolArea;
    private float minX, minZ, maxX, maxZ;

    [SerializeField]
    private Vector3 targetSpot;

    public float Offset;

    private float waitTime;
    public float startWaitTime = 2;

    // Start is called before the first frame update

    public INPS_State ChangeState(NPS_StateController npc)
    {
        PatrolArea(npc);
        return npc.idle;
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

    // Update is called once per frame
    private void Update()
    {
        //npsNavMesh.SetDestination(targetSpot);

        //if (Vector3.Distance(transform.position, targetSpot) < Offset)
        //{
        //    if (waitTime <= 0)
        //    {
        //        FindNewPoint();
        //        waitTime = startWaitTime;
        //    }
        //    else
        //    {
        //        waitTime -= Time.deltaTime;
        //    }
        //}
    }

    private void FindNewPoint()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        targetSpot = new Vector3(randomX, patrolArea.position.y, randomZ);
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
}