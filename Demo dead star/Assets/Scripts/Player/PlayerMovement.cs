using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    CharacterController controller;
    Animator anim;
    Vector3 direction;
    // Start is called before the first frame update


    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movingDirectionX = Input.GetAxisRaw("Horizontal") ;
        float movingDirectionZ = Input.GetAxisRaw("Vertical");

      
        direction = new Vector3(movingDirectionX, 0, movingDirectionZ).normalized;
        anim.SetFloat("Speed", direction.magnitude);
    }

    private void FixedUpdate()
    {
        controller.Move(direction * speed * Time.fixedDeltaTime);
    }

}
