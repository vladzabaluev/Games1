using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AggressiveShooterState : NPC_AgressiveState
{
    public GameObject Rocket;
    public Transform rocketMuzzle;

    protected override IEnumerator Attack(NPC_Controller NPC, float delay)
    {
        Instantiate(Rocket, rocketMuzzle.position, Quaternion.Euler(0, transform.eulerAngles.y, 0), null);
        yield return new WaitForSeconds(delay);
        Rocket.GetComponent<RocketBrain>().Damage = NPC.aggressive.Damage;
        //   return base.Attack(NPC, delay);
    }
}