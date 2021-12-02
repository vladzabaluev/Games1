using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour
{
    public float mouseSens = 100f;

    float xRot = 0;
    public float maxLookDownAngle = 80;
    public float maxLookUpAngle = 80;
    GameObject player;

    private bool _isActive;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetLockCursor(true);
    }
    public void SetLockCursor(bool mode) 
    {
        if (mode)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _isActive = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            _isActive = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (_isActive) 
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -maxLookDownAngle, maxLookUpAngle); //не делайте так, чтобы минус на минус было

            transform.localRotation = Quaternion.Euler(xRot, 0, 0);
            player.transform.Rotate(Vector3.up * mouseX);
        }
    }
}
