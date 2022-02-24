using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clicked : MonoBehaviour, Interaction
{
    public int id;

    public static int id_st;

    public UnityEvent<bool> _eventOpen;
    public UnityEvent<bool> _eventClose;
    //void OnMouseDown(){
    //    DataBase.i = id-1;
    //    id_st = id;
    //}

    public void Interact() 
    {
        DataBase.i = id - 1;
        id_st = id;
        _eventOpen.Invoke(false);
    }
}
