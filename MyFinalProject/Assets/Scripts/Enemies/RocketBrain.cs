using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBrain : MonoBehaviour
{
    public float speed = 10;
    public ParticleSystem BOOM_Effect;
    public float LifeTime = 2;

    private Rigidbody rb;

    public int Damage = 10;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DeadRocket(LifeTime));
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.fixedDeltaTime * 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        //проверка
        if (other.CompareTag("Player"))
        {
            GlobalEventManager.instanse.player.GetComponent<PlayerStats>().TakeDamage(Damage);
        }
        if (!other.CompareTag("Shooter"))
            StartCoroutine(DestroyRocket());
        //уничтожить ракету с проверкой если попало в героя
    }

    private IEnumerator DeadRocket(float timeBeforeBoom) //убить ракету потому шо долго живет
    {
        Debug.Log("0");
        yield return new WaitForSeconds(timeBeforeBoom);
        Debug.Log("2");
        StartCoroutine(DestroyRocket());
    }

    private IEnumerator DestroyRocket()
    {
        //off model
        //play destroy anim
        yield return new WaitForSeconds(BOOM_Effect.main.duration); //wait until anim dont end
        Destroy(gameObject);
    }
}