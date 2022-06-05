using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public ParticleSystem DeadEffect;
    public ParticleSystem DamageEffect;

    public Transform deadEfPosition;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        DamageEffect.Play();
    }

    public override void Die()
    {
        base.Die();
        Instantiate(DeadEffect, deadEfPosition.position, Quaternion.Euler(-90, 0, 0), null);
        Destroy(gameObject);
    }
}