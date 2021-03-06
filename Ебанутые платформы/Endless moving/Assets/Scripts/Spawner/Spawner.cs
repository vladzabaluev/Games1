using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject topSpawner;
    public GameObject botSpawner;
    public GameObject platforms;

    public float startTimeBtwSpawns;
    float timeBtwSpawns;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int rand=1;
            if (Score.score < 10)
            {
                rand = 2;
            }
            else if (Score.score < 20)
            {
                rand = 3;
            }
            else if (Score.score < 30)
            {
                rand = 4;
            }
  
            for (int i = 0; i < rand; i++)
            {
                spawn();
            }
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

    private void spawn()
    {
        Vector3 spawnPlace = new Vector3(botSpawner.transform.position.x, 
            Random.Range(botSpawner.transform.position.y, topSpawner.transform.position.y), 
            botSpawner.transform.position.z);
        Instantiate(platforms, spawnPlace, Quaternion.identity);
    }
}
