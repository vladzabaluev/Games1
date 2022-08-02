using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : IPlayerState
{
    private int enemyCount;
    private StateController stateController;

    [SerializeField] private float TurnVelocity = 10f;

    public IPlayerState DoState(StateController playerStateController)
    {
        Vector3 target;
        stateController = playerStateController;
        if (enemyCount <= 0)
        {
            target = new Vector3();
            stateController.PlayerNavMeshAgent.isStopped = false;
            stateController.MovingState.InitializedState(stateController);
            return stateController.MovingState;
        }
        else
        {
            target = stateController.WayPoints[stateController.PointNumber].Enemies[0].transform.position - stateController.transform.position;
            target.y = 0;
            stateController.transform.rotation = Quaternion.RotateTowards(stateController.transform.rotation, Quaternion.LookRotation(target), TurnVelocity * Time.deltaTime);

            return stateController.ShootingState;
        }
    }

    public void InitializedState(StateController playerStateController)
    {
        stateController = playerStateController;
        stateController.WayPoints[stateController.PointNumber].OnEnemiesCountChanged.AddListener(ChangeEnemyCount);
        enemyCount = stateController.GetEnemiesCount();
    }

    private void ChangeEnemyCount()
    {
        enemyCount = stateController.GetEnemiesCount();
    }
}