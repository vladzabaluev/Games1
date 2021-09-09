using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBomb : MonoBehaviour
{
    public Transform leftSpawner; 
    public Transform rightSpawer;  

    public GameObject bomb;

    public float timeBeforeExplosion;
    private float duringTime;

    void Update()
    {
        if (duringTime <= 0)
        {
            Vector3 place = new Vector3(Random.Range(leftSpawner.position.x, rightSpawer.position.x),
                leftSpawner.position.y, leftSpawner.position.z);
            Instantiate(bomb, place, Quaternion.identity);
            duringTime = timeBeforeExplosion;    
        }
        else
        {
            duringTime -= Time.deltaTime;
        }
    }
}
