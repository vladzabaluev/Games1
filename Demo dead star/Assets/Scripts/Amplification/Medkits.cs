using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkits : MonoBehaviour
{
    public int healAmount;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerHealthSystem>().NeadHealing(healAmount))
            {
                Destroy(gameObject);
            }

        }
    }
}
