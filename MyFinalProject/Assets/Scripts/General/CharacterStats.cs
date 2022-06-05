using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;

    [SerializeField]
    private int currentHP;

    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = maxHealth;
        currentHP = CurrentHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        currentHP = CurrentHealth;
        Debug.Log(transform.name + " takes " + damage);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
    }
}