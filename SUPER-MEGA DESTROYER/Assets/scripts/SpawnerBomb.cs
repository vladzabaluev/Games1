using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBomb : MonoBehaviour
{
    public Transform spawn1; 
    public Transform spawn2;  
    public Transform spawn3;   
    public Transform spawn4;
    public Transform spawn5;
    public Transform spawn6;
    public Transform spawn7;
    public Transform spawn8;

    public GameObject bomb;

    public float timeRespawn;
    private float deltaTime;

    void Update()
    {
        if (deltaTime <= 0)
        {
            int f = Random.Range(1, 4);
            switch (f)
            {
               
                case 1:
                    Instantiate(bomb, spawn1.position, spawn1.rotation);
                    Instantiate(bomb, spawn5.position, spawn5.rotation);
                    break;
                case 2:
                    Instantiate(bomb, spawn2.position, spawn2.rotation);
                    Instantiate(bomb, spawn6.position, spawn6.rotation);
                    break;
                case 3:
                    Instantiate(bomb, spawn3.position, spawn3.rotation);
                    Instantiate(bomb, spawn7.position, spawn7.rotation);
                    break;
                case 4:
                    Instantiate(bomb, spawn4.position, spawn4.rotation);
                    Instantiate(bomb, spawn8.position, spawn8.rotation);
                    break;


            }
            deltaTime = timeRespawn;    

        }
        else
        {
            deltaTime -= Time.deltaTime;
        }
    }
}
