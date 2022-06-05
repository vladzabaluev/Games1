using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AggressiveShooterState : NPS_AgressiveState
{
    public GameObject Rocket;
    public Transform rocketMuzzle;

    protected override IEnumerator Attack(NPS_StateController NPC, float delay)
    {
        Instantiate(Rocket, rocketMuzzle.position, Quaternion.Euler(0, transform.eulerAngles.y, 0), null);
        Rocket.GetComponent<RocketBrain>().Damage = NPC.aggressive.Damage;
        return base.Attack(NPC, delay);
    }
}