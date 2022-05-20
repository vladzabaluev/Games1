using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPS_StateController : MonoBehaviour
{
    [SerializeField]
    private INPS_State currentState;

    public NPS_IdleState idle;
    public NPS_AgressiveState aggressive;

    public NavMeshAgent npsNavMesh;

    public float aggrRadius = 10;

    public Transform target;

    public Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        npsNavMesh = GetComponent<NavMeshAgent>();
        idle = GetComponent<NPS_IdleState>();
        aggressive = GetComponent<NPS_AgressiveState>();
        anim = GetComponentInChildren<Animator>();
        target = GlobalEventManager.instanse.player.transform;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, aggrRadius);
    }
}