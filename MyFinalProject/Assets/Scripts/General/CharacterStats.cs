using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;

    [SerializeField]
    private int currentHP;

    public int currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = maxHealth;
        currentHP = currentHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHP = currentHealth;
        Debug.Log(transform.name + " takes " + damage);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
    }
}