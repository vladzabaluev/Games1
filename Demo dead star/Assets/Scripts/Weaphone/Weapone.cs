using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapone : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Instantiate(bullet, firePoint.position, Quaternion.identity); //стрельба с помощью префаба

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //стрельба рейкастом
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    Debug.Log("Попал в противника");
                }
            }
        }

    }
}
