using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private void Start()
    {
        GlobalEventManager.SendPlayerDamaged(currentHealth);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        GlobalEventManager.SendPlayerDamaged(currentHealth);
    }
}