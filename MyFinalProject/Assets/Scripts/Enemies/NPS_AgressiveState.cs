using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPS_AgressiveState : MonoBehaviour
{
    private NavMeshAgent npsNavMesh;

    public float aggrRadius = 10;
    private Transform target;

    // Start is called before the first frame update
    private void Start()
    {
        npsNavMesh = GetComponent<NavMeshAgent>();
        target = PlayerManager.instanse.player.transform;
    }

    // Update is called once per frame
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= aggrRadius)
        {
            npsNavMesh.SetDestination(target.position);

            if (distance <= npsNavMesh.stoppingDistance)
            {
                LookAtTheTarget();
            }
        }
    }

    private void LookAtTheTarget()
    {
        Vector3 targetRotation = target.position - transform.position;
        targetRotation = targetRotation.normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(targetRotation.x, 0, targetRotation.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, aggrRadius);
    }
}