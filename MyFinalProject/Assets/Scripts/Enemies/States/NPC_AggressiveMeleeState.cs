using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AggressiveMeleeState : NPS_AgressiveState
{
    protected override IEnumerator Attack(NPS_StateController NPC, float delay)
    {
        NPC.target.GetComponent<PlayerStats>().TakeDamage(Damage);
        return base.Attack(NPC, delay);
    }
}