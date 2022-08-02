using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoving : MonoBehaviour
{
    private NavMeshAgent playerNavMeshAgent;
    public List<WayPoint> WayPoints;
    private Vector3 targetPosition;
    private int pointNumber = 0;

    // Start is called before the first frame update
    private void Start()
    {
        playerNavMeshAgent = GetComponent<NavMeshAgent>();

        transform.position = WayPoints[pointNumber].transform.position;
        ChangeTarget();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            ChangeTarget();
        }
    }

    private void ChangeTarget()
    {
        if (pointNumber > WayPoints.Count - 1)
        {
            Debug.Log("End");
        }
        else
        {
            pointNumber++;
            targetPosition = WayPoints[pointNumber].transform.position;
            playerNavMeshAgent.SetDestination(targetPosition);
        }
    }
}