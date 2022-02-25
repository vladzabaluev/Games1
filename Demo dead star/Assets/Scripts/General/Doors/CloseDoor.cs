using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    Door DC1;
    Door DC2;
    // Start is called before the first frame update
    void Start()
    {
        DC1 = transform.GetChild(0).GetComponent<Door>();
        DC2 = transform.GetChild(1).GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DC1.needToClose && DC2.needToClose)
        {
            DC1.CloseDoor();
            DC2.CloseDoor();
        }
        //else
        //{
        //    enabled = false;
        //}
    }
}
