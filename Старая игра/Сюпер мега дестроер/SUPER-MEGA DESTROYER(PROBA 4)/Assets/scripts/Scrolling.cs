using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public bool scrolling, paralax;

    public float backgroundSize;
    public float paralaxSpeed;


    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone=15f;
    private int leftIndex;
    private int rightIndex;

    private float lastcameraX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        lastcameraX = cameraTransform.position.x;

        for (int i=0; i<transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length-1;
         
    }
    private void Update()
    {
       
        if (paralax)
        {
            float deltaX = cameraTransform.position.x - lastcameraX;
            transform.position += Vector3.right * (deltaX * paralaxSpeed);
        }

        
        lastcameraX = cameraTransform.position.x;

        if (scrolling)
        {

            if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
            {
                ScrollLeft();
            }
            if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
            {
                ScrollRight();
            }
        }
    }
    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;

        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }
    private void ScrollRight() 
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;

        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }

}
