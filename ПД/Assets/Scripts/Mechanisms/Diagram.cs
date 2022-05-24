using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diagram : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public CameraRotater cameraRotater;

    // Start is called before the first frame update
    private void OnEnable()
    {
        playerMovement.SetMode(false);
        cameraRotater.SetLockCursor(false);
    }

    private void OnDisable()
    {
        playerMovement.SetMode(true);
        cameraRotater.SetLockCursor(true);
    }
}