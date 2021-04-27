using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scrolling : MonoBehaviour
{
    public float backGroundSize;

    private Transform cameraTransform;
    private Transform [] grounds;


    private int leftIndex;
    private int rightIndex;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        grounds = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            grounds[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = grounds.Length - 1;

    }



    private void ScrollRight()
    {
        grounds[leftIndex].position = Vector3.right * (grounds[rightIndex].position.x + backGroundSize);
        rightIndex = leftIndex;
        leftIndex++;

        if (leftIndex == grounds.Length)
        {
            leftIndex = 0;
        }
   
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTransform.position.x > (grounds[rightIndex].transform.position.x ))
        {
            ScrollRight();
        }
        
    }
}
