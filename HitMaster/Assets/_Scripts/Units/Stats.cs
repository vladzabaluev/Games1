using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxHealth = 100;

    [SerializeField]
    protected int currentHP;

    // Start is called before the first frame update

    //public virtual void SetCurrentHealth()
    //{
    //}
    protected virtual void Start()
    {
        currentHP = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Dead();
        }
    }

    // Update is called once per frame
    protected virtual void Dead()
    {
    }
}