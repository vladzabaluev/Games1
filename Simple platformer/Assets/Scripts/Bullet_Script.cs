using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    public GameObject hitEffect;

    public int damage = 40;
    public float speed = 20f;
    public float lifeTime = 1f;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {  
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hittedThings)
    {
        if (hittedThings.transform.tag == "Enemy")
        {
            hittedThings.transform.GetComponent<Enemy_HealthSystrm>().TakeDamage(damage);
            GameObject Effect_hit = Instantiate(hitEffect, hittedThings.transform.position, Quaternion.identity);   
            Destroy(Effect_hit, 1);
            Destroy(gameObject);
        }
    }
}
