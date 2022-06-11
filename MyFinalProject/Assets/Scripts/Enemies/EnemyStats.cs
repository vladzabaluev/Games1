using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public ParticleSystem DeadEffect;
    public ParticleSystem DamageEffect;

    public Transform deadEfPosition;

    public static int EnemiesOnLVL = 0;

    private void Start()
    {
        EnemiesOnLVL++;
        GlobalEventManager.SendEnemyDead(EnemiesOnLVL);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        DamageEffect.Play();
    }

    public override void Die()
    {
        EnemiesOnLVL--;
        base.Die();
        Instantiate(DeadEffect, deadEfPosition.position, Quaternion.Euler(-90, 0, 0), null);
        GlobalEventManager.SendEnemyDead(EnemiesOnLVL);
        Destroy(gameObject);
    }
}