using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject fire;
    public GameObject thereSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateFire()
    {
        Instantiate(fire, thereSpawn.transform.position, Quaternion.identity);
    }

}
