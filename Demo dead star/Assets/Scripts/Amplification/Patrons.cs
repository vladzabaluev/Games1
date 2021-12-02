using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrons : MonoBehaviour
{
    public int addingPatrons;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Weapone>().topUpPatrons(addingPatrons)) 
            {
                Destroy(gameObject);
            }

        }
    }
}
