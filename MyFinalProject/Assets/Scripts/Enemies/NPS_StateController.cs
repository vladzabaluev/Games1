using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPS_StateController : MonoBehaviour
{
    [SerializeField]
    private INPS_State currentState;

    public NPS_IdleState idle = new NPS_IdleState();
    public NPS_AgressiveState aggressive = new NPS_AgressiveState();

    public NavMeshAgent npsNavMesh;

    // Start is called before the first frame update
    private void Start()
    {
        npsNavMesh = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        currentState = idle;
    }

    // Update is called once per frame
    private void Update()
    {
        currentState = currentState.ChangeState(this);
    }
}