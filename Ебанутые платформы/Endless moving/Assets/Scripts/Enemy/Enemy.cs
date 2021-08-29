using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minRotSpeed;
    public float maxRotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, Random.Range(-90, 90));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, transform.localRotation.z+Random.Range(minRotSpeed,maxRotSpeed));
    }
}
