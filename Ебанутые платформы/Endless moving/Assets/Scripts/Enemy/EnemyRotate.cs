using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    public float minRotSpeed;
    public float maxRotSpeed;
    float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, Random.Range(-90, 90));
        rotationSpeed = Random.Range(minRotSpeed, maxRotSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed*Time.deltaTime);
    }

}
