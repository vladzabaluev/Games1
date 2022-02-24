using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEat : MonoBehaviour
{
    public GameObject[] poolOFEatHoles;

    private void Start()
    {
        newHole();
    }
    public void newHole()
    {       
        transform.position = poolOFEatHoles[Random.Range(0, poolOFEatHoles.Length)].transform.position;
    }
}
