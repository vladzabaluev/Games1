using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    [SerializeField]
    public INPC_State currentState;

    public NPC_IdleState idle;
    public NPC_AgressiveState aggressive;

    public NavMeshAgent npcNavMesh;

    public float aggrRadius = 10;

    public Transform target;

    public Animator anim;

    // Start is called before the first frame update

    private void Start()
    {
        npcNavMesh = GetComponent<NavMeshAgent>();
        idle = GetComponent<NPC_IdleState>();
        aggressive = GetComponent<NPC_AgressiveState>();
        anim = GetComponentInChildren<Animator>();
        target = GlobalEventManager.instanse.player.transform;

        currentState = idle;
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