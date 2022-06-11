using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBrain : MonoBehaviour
{
    public float speed = 10;
    public ParticleSystem BOOM_Effect;
    public float LifeTime = 2;

    public float boomOffset;
    private Rigidbody rb;

    public int Damage = 10;
    private Vector3 boomPoint;

    [SerializeField]
    private Sound LaunchSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DeadRocket(LifeTime));
        audioSource = gameObject.AddComponent<AudioSource>();
        AudioManager.PlaySound(LaunchSound, audioSource, false, false);
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
        //if (!other.CompareTag("Shooter"))
        DestroyRocket();
        //уничтожить ракету с проверкой если попало в героя
    }

    private IEnumerator DeadRocket(float timeBeforeBoom) //убить ракету потому шо долго живет
    {
        yield return new WaitForSeconds(timeBeforeBoom);
        DestroyRocket();
    }

    private void DestroyRocket()
    {
        boomPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z - boomOffset);
        Instantiate(BOOM_Effect, boomPoint, Quaternion.identity, null);
        Destroy(gameObject);
    }
}