using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursorController : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        SetCursor(false);
    }

    private void OnApplicationFocus(bool focus)
    {
        SetCursor(!focus);
    }

    public static void SetCursor(bool mode)
    {
        if (mode)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}