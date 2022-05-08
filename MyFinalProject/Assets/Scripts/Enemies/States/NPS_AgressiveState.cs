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
        if (Vector3.Distance(transform.position, npc.target.position) <= npc.npsNavMesh.stoppingDistance)
        {
            //Сделать метод атаки через корутины и подумать над тем, чтобы не переписывать все по 20 раз
            //а сделать так, чтобы 1 скрипт решал вопросы атаки как дальнего боя, так и ближнего
            npc.target.GetComponent<PlayerStats>().TakeDamage(1);
        }
    }

    private void LookAtTheTarget(NPS_StateController npc)
    {
        Vector3 targetRotation = npc.target.position - transform.position;
        targetRotation = targetRotation.normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(targetRotation.x, 0, targetRotation.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }
}