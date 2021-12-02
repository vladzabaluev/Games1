using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15;
    CharacterController playerController;
    // Start is called before the first frame update
    private bool _isActive = true;


    public void SetMode(bool mode) 
    {
        _isActive = mode;
    }
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        SetMode(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 direction = transform.right * x + transform.forward * z;

            playerController.Move(direction * speed * Time.deltaTime);
        }
    }
}
