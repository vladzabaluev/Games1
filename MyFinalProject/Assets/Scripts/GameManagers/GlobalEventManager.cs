using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GlobalEventManager : MonoBehaviour
{
    #region Singleton

    public static GlobalEventManager instanse;

    private void Awake()
    {
        instanse = this;
        Time.timeScale = 1;
    }

    #endregion Singleton

    public GameObject player;

    public static readonly UnityEvent<int> OnPlayerDamaged = new UnityEvent<int>();
    public static readonly UnityEvent<Weaphone> OnBulletAmountChanged = new UnityEvent<Weaphone>();
    public static readonly UnityEvent OnPlayerDead = new UnityEvent();
    public static readonly UnityEvent OnGamePaused = new UnityEvent();
    public static readonly UnityEvent OnGameUnpaused = new UnityEvent();

    public static readonly UnityEvent<int> EnemyCount = new UnityEvent<int>();
    public static readonly UnityEvent OnAllEnemiesDead = new UnityEvent();

    public static void SendPlayerDamaged(int currentHealth) => OnPlayerDamaged.Invoke(currentHealth);

    public static void SendBulletAmountChanged(Weaphone weaphone) => OnBulletAmountChanged.Invoke(weaphone);

    public static void SendPlayerDead() => OnPlayerDead.Invoke();

    public static void SendGamePaused() => OnGamePaused.Invoke();

    public static void SendGameUnpaused() => OnGameUnpaused.Invoke();

    public static void SendEnemyCount(int enemiesLeft)
    {
        EnemyCount.Invoke(enemiesLeft);
        if (enemiesLeft < 1)
        {
            SendAllEnemiesDead();
        }
    }

    private static void SendAllEnemiesDead()
    {
        OnAllEnemiesDead.Invoke();
    }
}