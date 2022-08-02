using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    [SerializeField] private HealthBar healthBar;

    protected override void Start()
    {
        base.Start();
        healthBar.SetValue(maxHealth, maxHealth);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        healthBar.SetValue(currentHP, maxHealth);
    }

    protected override void Dead()
    {
        base.Dead();
        GetComponent<Enemy>().EnemyDead();
    }
}