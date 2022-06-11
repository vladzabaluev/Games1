using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AggressiveMeleeState : NPC_AgressiveState
{
    protected override IEnumerator Attack(NPC_Controller NPC, float delay)
    {
        if (AttackRange < NPC.npcNavMesh.stoppingDistance)
        {
            Debug.LogWarning("Attack range less than Stopping Distance. Enemy can don't attack the player");
        }
        yield return new WaitForSeconds(delay);
        NPC.target.GetComponent<PlayerStats>().TakeDamage(Damage);
        //return base.Attack(NPC, delay);
    }
}