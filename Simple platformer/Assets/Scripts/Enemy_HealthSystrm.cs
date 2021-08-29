using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HealthSystrm : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public GameObject deadEffect;

    public Healthbar hp;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hp.SetMaxValue(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        hp.SetValue(currentHealth);
    }

    void Die()
    {
        GameObject Effect_dead = Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(Effect_dead, 1f);
        Destroy(gameObject);
    }
}
