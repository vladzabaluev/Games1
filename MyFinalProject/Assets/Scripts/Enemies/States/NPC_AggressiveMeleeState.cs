using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AggressiveMeleeState : NPC_AgressiveState
{
    protected override IEnumerator Attack(NPC_Controller NPC, float delay)
    {
        NPC.target.GetComponent<PlayerStats>().TakeDamage(Damage);
        return base.Attack(NPC, delay);
    }
}