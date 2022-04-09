using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPS_AgressiveState : MonoBehaviour, INPS_State
{
    public INPS_State ChangeState(NPS_StateController npc)
    {
        FollowPlayer(npc);
        return this;
    }

    private void FollowPlayer(NPS_StateController npc)
    {
        npc.npsNavMesh.SetDestination(npc.target.position);
        LookAtTheTarget(npc);
    }

    private void LookAtTheTarget(NPS_StateController npc)
    {
        Vector3 targetRotation = npc.target.position - transform.position;
        targetRotation = targetRotation.normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(targetRotation.x, 0, targetRotation.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }
}