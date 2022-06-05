using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStart : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
        }
    }
}