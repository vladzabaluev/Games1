using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject[] bullets;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(bullets[0], transform.position, Quaternion.identity);
        } 
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(bullets[1], transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(bullets[2], transform.position, Quaternion.identity);
        }

    }
}
