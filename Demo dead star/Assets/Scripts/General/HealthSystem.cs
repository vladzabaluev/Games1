using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    int maxHealth; 
    int health;
    Healthbar hp;

    public void EnterHealth(int mH, Healthbar healhtbar)
    {
        this.maxHealth = mH;
        health = maxHealth;
        hp = healhtbar;
        hp.SetMaxHealth(mH);

    }
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        hp.SetHealth(health);
        if (health <= 0)
        {
            Dead();
        }
    }

    public virtual bool NeadHealing(int heal)
    {
        if (health < maxHealth)
        {
            if (health + heal <= maxHealth)
            {
                health += heal;
            }
            else
            {
                health = maxHealth;
            }
            hp.SetHealth(health);
            return true;
        }
        else
        {
            return false;
        }

    }
    public abstract void Dead();
}
