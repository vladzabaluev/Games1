using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatController : MonoBehaviour
{
    GameObject eat;
    NavMeshAgent ratMover;

    public TakeSmth takeScript;
    // Start is called before the first frame update
    void Start()
    {
        eat = GameObject.FindGameObjectWithTag("Eat for reactor");
        ratMover = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!takeScript.isCarries)
        {
            ratMover.SetDestination(eat.transform.position);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Eat for reactor"))
        {
            other.GetComponent<MoveEat>().newHole();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Eat for reactor"))
        {
            other.GetComponent<MoveEat>().newHole();
        }
    }
}
