using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_AgressiveState : MonoBehaviour, INPC_State
{
    //public float TimeBetweenAttack = 1;
    public float AttackPerSecond = 2;

    public int Damage = 5;
    private float attackCooldown;

    public float AttackRange = 7f;

   // public bool newDevide;

    public INPC_State ChangeState(NPC_Controller NPC)
    {
        FollowPlayer(NPC);
        return this;
    }

    private void FollowPlayer(NPC_Controller NPC)
    {
        NPC.npcNavMesh.SetDestination(NPC.target.position);
        if (Vector3.Distance(transform.position, NPC.target.position) <= AttackRange)
        {
            LookAtTheTarget(NPC);
            NPC.npcNavMesh.isStopped = true;
            if (attackCooldown <= 0)
            {
                NPC.anim.SetTrigger("isAttack");
                StartCoroutine(Attack(NPC, NPC.anim.GetCurrentAnimatorClipInfo(0)[0].clip.length));
                attackCooldown = 1 / AttackPerSecond;
            }
            else
            {
                attackCooldown -= Time.deltaTime;
            }
            //Сделать метод атаки через корутины и подумать над тем, чтобы не переписывать все по 20 раз
            //а сделать так, чтобы 1 скрипт решал вопросы атаки как дальнего боя, так и ближнего
        }
        else
        {
            NPC.npcNavMesh.isStopped = false;
        }
    }

    private void LookAtTheTarget(NPC_Controller NPC)
    {
        Vector3 targetRotation = NPC.target.position - transform.position;
        targetRotation = targetRotation.normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(targetRotation.x, 0, targetRotation.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
        //if (transform.rotation == lookRotation)
        //{
        //    return true;
        //}
        //else
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
        //    return false;
        //}
    }

    protected virtual IEnumerator Attack(NPC_Controller NPC, float delay)
    {
        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}