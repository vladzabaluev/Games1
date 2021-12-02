using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_question : MonoBehaviour
{
    public GameObject cunv;
    public static bool created = false;
    public static int i=-1;



    void Update(){

        if (i!=-1 && !created)
        {
            //Instantiate(cunv, new Vector3(0,0,-100), Quaternion.identity);

            created = true;
        }

    }

}
