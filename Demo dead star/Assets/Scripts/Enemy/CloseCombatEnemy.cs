using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCombatEnemy : MonoBehaviour
{
    public float attackPerSecond;
    public float nextTimeAttack;
    public float attackRange;

    public int damage;

    LayerMask _playerLayer;
    Transform _attackPoint;
    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerLayer = _player.layer;
        _attackPoint = transform.GetChild(1);
    }

    // Update is called once per frame
    public void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_attackPoint.position, attackRange, _playerLayer);
        if (hitColliders != null)
        {
            _player.GetComponent<PlayerHealthSystem>().TakeDamage(damage);
            nextTimeAttack = Time.time + 1 / attackRange;
        }

    }

    private void OnDrawGizmosSelected()
    {
        if(_attackPoint!=null)
            Gizmos.DrawWireSphere(_attackPoint.position, attackRange);
    }
}
