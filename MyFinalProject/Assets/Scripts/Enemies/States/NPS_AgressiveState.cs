using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPS_AgressiveState : MonoBehaviour, INPS_State
{
    public float TimeBetweenAttack = 1;
    public float AttackPerSecond = 2;
    public int Damage = 5;
    private float attackCooldown;

    public INPS_State ChangeState(NPS_StateController nps)
    {
        FollowPlayer(nps);
        return this;
    }

    private void FollowPlayer(NPS_StateController nps)
    {
        nps.npsNavMesh.SetDestination(nps.target.position);
        LookAtTheTarget(nps);
        if (Vector3.Distance(transform.position, nps.target.position) <= nps.npsNavMesh.stoppingDistance)
        {
            if (attackCooldown <= 0)
            {
                nps.anim.SetTrigger("isAttack");
                StartCoroutine(Attack(nps, nps.anim.GetCurrentAnimatorClipInfo(0)[0].clip.length));
                attackCooldown = 1 / AttackPerSecond;
            }
            else
            {
                attackCooldown -= Time.deltaTime;
            }
            //Сделать метод атаки через корутины и подумать над тем, чтобы не переписывать все по 20 раз
            //а сделать так, чтобы 1 скрипт решал вопросы атаки как дальнего боя, так и ближнего
        }
    }

    private void LookAtTheTarget(NPS_StateController nps)
    {
        Vector3 targetRotation = nps.target.position - transform.position;
        targetRotation = targetRotation.normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(targetRotation.x, 0, targetRotation.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }

    private IEnumerator Attack(NPS_StateController nps, float delay)
    {
        yield return new WaitForSeconds(delay);
        nps.target.GetComponent<PlayerStats>().TakeDamage(Damage);
    }
}