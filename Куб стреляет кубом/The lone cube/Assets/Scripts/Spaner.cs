using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaner : MonoBehaviour
{
    public GameObject[] enemies;
    public float startTimeBtwShoots;

    private float timeBtwShoots;

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShoots <= 0)
        {
            int whichEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[whichEnemy], transform.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShoots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }

    }
}
