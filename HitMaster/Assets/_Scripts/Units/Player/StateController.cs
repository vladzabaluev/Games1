using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public NavMeshAgent PlayerNavMeshAgent;

    public MovingState MovingState = new MovingState();

    [SerializeReference]
    public ShootingState ShootingState = new ShootingState();

    private IPlayerState currentState;

    public List<WayPoint> WayPoints;
    public int PointNumber = 0;

    private Animator anim;

    private void Awake()
    {
        transform.position = WayPoints[0].transform.position;
    }

    // Start is called before the first frame update
    private void Start()
    {
        PlayerNavMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        currentState = MovingState;
        currentState.InitializedState(this);
    }

    private void OnEnable()
    {
        //currentState = ShootingState;
        //currentState.InitializedState(this);
    }

    // Update is called once per frame
    private void Update()
    {
        currentState = currentState.DoState(this);

        if (currentState == ShootingState)
            anim.SetBool("isMoving", false);
        else if (currentState == MovingState)
            anim.SetBool("isMoving", true);
    }

    public int GetEnemiesCount()
    {
        return WayPoints[PointNumber].Enemies.Count;
    }
}