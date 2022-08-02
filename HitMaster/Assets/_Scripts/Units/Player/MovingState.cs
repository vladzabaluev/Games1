using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : IPlayerState
{
    private Vector3 targetPosition;

    public IPlayerState DoState(StateController playerStateController)
    {
        if (Vector3.Distance(playerStateController.transform.position, targetPosition) < 0.5f)
        {
            if (playerStateController.PointNumber >= playerStateController.WayPoints.Count - 1)
            {
                GameManager.Restart();
                return null;
            }

            playerStateController.PlayerNavMeshAgent.isStopped = true;
            playerStateController.ShootingState.InitializedState(playerStateController);
            return playerStateController.ShootingState;
        }
        else
        {
            return playerStateController.MovingState;
        }
    }

    public void InitializedState(StateController playerStateController)
    {
        MoveToNextPoint(playerStateController);
    }

    public void MoveToNextPoint(StateController playerStateController)
    {
        playerStateController.PointNumber++;
        targetPosition = playerStateController.WayPoints[playerStateController.PointNumber].transform.position;
        playerStateController.PlayerNavMeshAgent.SetDestination(targetPosition);
    }
}