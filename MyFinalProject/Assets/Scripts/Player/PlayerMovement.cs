using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputActions p_Input;
    private CharacterController p_Controller;

    private InputAction i_move;
    private InputAction i_jump;

    public float Speed = 10f;

    public float jumpHeight=10;
    public float gravityConst = -9.81f;

    public float groundCheckRadius = 1.2f;
    public float groundCheckOffset = 1f;
    public bool isGrounded;

    private float fallVelocity;

    // Start is called before the first frame updat
    private void Awake()
    {
        p_Input = new PlayerInputActions();
    }
    private void OnEnable()
    {
        i_move = p_Input.Player.Move;

        i_jump = p_Input.Player.Jump;

        i_jump.started += DoJump;
        i_move.Enable();
        i_jump.Enable();
    }

    private void OnDisable()
    {
        i_move.Disable();
        i_jump.Disable();
    }
    void Start()
    {
        p_Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GroundCheck();
        Gravity();
    }


    private void DoJump(InputAction.CallbackContext obj)
    {
        if (isGrounded)
        {
            fallVelocity = Mathf.Sqrt(jumpHeight * -2f * gravityConst);
        }
    }

    private void Move()
    {
        Vector3 inputDirection = new Vector3(i_move.ReadValue<Vector2>().x, 0, i_move.ReadValue<Vector2>().y).normalized;
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        Vector3 movingDirection = transform.right * inputDirection.x + transform.forward * inputDirection.z;
        p_Controller.Move(movingDirection.normalized * Speed * Time.deltaTime + new Vector3(0, fallVelocity, 0) * Time.deltaTime);
    }

    private void Gravity()
    {
        if (isGrounded)
        {
            if (fallVelocity < 0)
            {
                fallVelocity = -2f;
            }

        }
        else
        {
            fallVelocity += gravityConst * Time.deltaTime;
        }
    }

    private void GroundCheck()
    {
        RaycastHit hitInfo;
        isGrounded = Physics.SphereCast(transform.position, groundCheckRadius, Vector3.down, out hitInfo, groundCheckOffset);
    }

    private void OnDrawGizmosSelected()
    {
        if (isGrounded)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.blue;
        }
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundCheckOffset, transform.position.z);
        Gizmos.DrawSphere(spherePosition, groundCheckRadius);
    }

   
}
