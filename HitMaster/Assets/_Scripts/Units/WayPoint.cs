using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WayPoint : MonoBehaviour
{
    public List<Enemy> Enemies;
    public UnityEvent OnEnemiesCountChanged = new UnityEvent();

    private void Start()
    {
        List<Enemy> nullEnemy = new List<Enemy>();
        foreach (Enemy enemy in Enemies)
        {
            if (enemy == null)
            {
                nullEnemy.Add(enemy);
            }
            else
            {
                enemy.OnEnemyDead.AddListener(EnemiesCountChanged);
            }
        }
        foreach (Enemy enemy in nullEnemy)
        {
            Enemies.Remove(enemy);
        }
        nullEnemy.Clear();
    }

    private void EnemiesCountChanged(Enemy enemy)
    {
        Enemies.Remove(enemy);
        OnEnemiesCountChanged.Invoke();
    }
}