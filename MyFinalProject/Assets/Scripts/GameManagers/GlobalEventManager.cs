using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent<int> OnPlayerDamaged = new UnityEvent<int>();
    public static UnityEvent<Weaphone> OnBulletAmountChanged = new UnityEvent<Weaphone>();

    public static void SendPlayerDamaged(int currentHealth) => OnPlayerDamaged.Invoke(currentHealth);

    public static void SendBulletAmountChanged(Weaphone weaphone) => OnBulletAmountChanged.Invoke(weaphone);
}