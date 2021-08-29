using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus_Controller : MonoBehaviour
{
    public Healthbar hp;

    public float patrolDistance = 3;
    public float speed = 40;
    Vector3 targetPosition;
    bool thenLeft = false;
    

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == targetPosition.x && thenLeft)
        {
            targetPosition = new Vector3(transform.position.x + patrolDistance * 2, transform.position.y, transform.position.z);
            thenLeft = !thenLeft;

            transform.rotation = Quaternion.AngleAxis(0, Vector3.up); //flip the enemy in the direction of mooving

            hp.transform.rotation = Quaternion.AngleAxis(180, Vector3.up); //flip health bar, because we dont need flip it with enemy
        }
        else if (transform.position.x == targetPosition.x && !thenLeft)
        {
            targetPosition = new Vector3(transform.position.x - patrolDistance * 2, transform.position.y, transform.position.z);
            thenLeft = !thenLeft;

            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);//flip the enemy in the direction of mooving

            hp.transform.rotation = Quaternion.AngleAxis(180, Vector3.up); //flip health bar, because we dont need flip it with enemy
        }
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
    }


    private void OnDrawGizmosSelected()
    {
        Vector3 line = new Vector3(2*patrolDistance, 0, 0);
        Gizmos.DrawLine(transform.position - line, transform.position - line + Vector3.up * 2);
    }
}
