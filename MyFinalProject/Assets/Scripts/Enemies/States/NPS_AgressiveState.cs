using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPS_AgressiveState : MonoBehaviour, INPS_State
{
    //public float TimeBetweenAttack = 1;
    public float AttackPerSecond = 2;

    public int Damage = 5;
    private float attackCooldown;

    public float AttackRange = 7f;

    public INPS_State ChangeState(NPS_StateController NPC)
    {
        FollowPlayer(NPC);
        return this;
    }

    private void FollowPlayer(NPS_StateController NPC)
    {
        NPC.npsNavMesh.SetDestination(NPC.target.position);
        if (Vector3.Distance(transform.position, NPC.target.position) <= AttackRange)
        {
            LookAtTheTarget(NPC);
            NPC.npsNavMesh.isStopped = true;
            if (attackCooldown <= 0)
            {
                if (LookAtTheTarget(NPC))
                {
                    NPC.anim.SetTrigger("isAttack");
                    StartCoroutine(Attack(NPC, NPC.anim.GetCurrentAnimatorClipInfo(0)[0].clip.length));
                    attackCooldown = 1 / AttackPerSecond;
                }
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
            NPC.npsNavMesh.isStopped = false;
        }
    }

    private bool LookAtTheTarget(NPS_StateController NPC)
    {
        Vector3 targetRotation = NPC.target.position - transform.position;
        targetRotation = targetRotation.normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(targetRotation.x, 0, targetRotation.z));
        if (transform.rotation == lookRotation)
        {
            return true;
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
            return false;
        }
    }

    protected virtual IEnumerator Attack(NPS_StateController NPC, float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}