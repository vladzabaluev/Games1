using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesTeam : MonoBehaviour
{
    public UnityEvent OneEnemyDamaged;

    public void SendOneEnemyDamaged()
    {
        OneEnemyDamaged.Invoke();
    }
}