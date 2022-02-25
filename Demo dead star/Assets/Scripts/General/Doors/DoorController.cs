using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorController : MonoBehaviour
{
    Door door1;
    Door door2;
    EnemyActivater enemyActiv;
    // Start is called before the first frame update
    void Start()
    {
        door1 = transform.GetChild(0).GetComponent<Door>();
        door2 = transform.GetChild(1).GetComponent<Door>();
        enemyActiv = GetComponentInParent<EnemyActivater>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            door1.MoveDoor(true);
            door2.MoveDoor(true);
            enemyActiv.activateEnemy();
        }
    }
   
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            door1.MoveDoor(false);
            door2.MoveDoor(false);
        }
    }
}
