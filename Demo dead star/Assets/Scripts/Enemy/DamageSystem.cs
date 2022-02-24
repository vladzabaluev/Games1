using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : HealthSystem
{
    public int mHealth;
    Healthbar botHP;
    // Start is called before the first frame update
    private void Start()
    {
        botHP = this.transform.GetChild(0).GetChild(0).GetComponentInChildren<Healthbar>();
        EnterHealth(mHealth, botHP); 
    }

    public override void Dead()
    {
        Destroy(gameObject);
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DamageSystem : MonoBehaviour
//{
//    public float health;
//    float damage;
//    // Start is called before the first frame update
//    public void TakeDamage()
//    {
//        health -= damage;
//        if (health <= 0)
//        {
//            Dead();
//        }
//    }

//    void Dead()
//    {
//        Destroy(gameObject);
//    }
//}