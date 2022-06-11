using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weaphone : ScriptableObject
{
    public int Damage;
    public float shootingRange;
    public float bulletPerSecond;

    public int bulIn—lip = 30;
    public int allBullets = 120;

    public int currentBulletInClip;
    public int currentAllBullet;

    public bool AutoShooting;
    public ShootingType shootingType;

    public Sound ShotSound;

    public enum ShootingType
    {
        Tap,
        Hold
    }

    public Color weaphoneColor;

    public void StartLVL()
    {
        currentBulletInClip = bulIn—lip;
        currentAllBullet = allBullets;
    }

    //public int Clip { get { return bulIn—lip; }  set { bulIn—lip = value; } }
}