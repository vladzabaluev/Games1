using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour

{
    public int Hitpoint=5;
    public virtual void ReceiveDamage()
    {
        Hitpoint--;
        Debug.Log(Hitpoint);
        if (Hitpoint == 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

}
