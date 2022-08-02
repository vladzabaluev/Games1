using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    private BoxCollider bodyColider;
    public UnityEvent<Enemy> OnEnemyDead = new UnityEvent<Enemy>();
    private Vector3 playerPosition;

    private void Start()
    {
        anim = GetComponent<Animator>();
        bodyColider = GetComponent<BoxCollider>();
        anim.enabled = true;
    }

    private void LateUpdate()
    {
        playerPosition = GameManager.Instance.Player.transform.position;
        transform.LookAt(playerPosition);
    }

    public void EnemyDead()
    {
        anim.enabled = false;
        bodyColider.enabled = false;
        OnEnemyDead.Invoke(this);
    }
}