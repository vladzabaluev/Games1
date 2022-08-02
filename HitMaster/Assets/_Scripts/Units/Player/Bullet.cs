using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private Rigidbody rb;
    private BulletPooler bulletPooler;
    public Vector3 Target;

    private void Start()
    {
        bulletPooler = BulletPooler.Instance;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = speed * Time.fixedDeltaTime * transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        bulletPooler.BackToPool(this);
        if (collision.gameObject.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
        {
            enemyStats.TakeDamage(damage);
        }
    }

    public void Shot(Vector3 target)
    {
        Target = target;
    }
}