using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float JumpForce = 50f;

    CharacterController controller;

    Vector3 direction;


    // Start is called before the first frame update


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float movingDirectionX = Input.GetAxisRaw("Horizontal") ;
        float movingDirectionZ = Input.GetAxisRaw("Vertical");

        direction = new Vector3(movingDirectionX, 0, movingDirectionZ).normalized;
    }

    private void FixedUpdate()
    {
        controller.Move(direction * speed*Time.fixedDeltaTime);
    }

    void Jump()
    {
       
    }
}
