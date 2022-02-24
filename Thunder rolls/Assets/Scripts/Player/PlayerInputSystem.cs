using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputSystem : MonoBehaviour
{
    public Vector3 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        JumpInput();
        SprintInput();
        MoveInput();
    }
    void JumpInput()
    {
        jump = Input.GetKeyDown(KeyCode.Space);
    }

    void SprintInput()
    {
        sprint = Input.GetKey(KeyCode.LeftShift);
    }
    void MoveInput()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = 0;
        move.z = Input.GetAxisRaw("Vertical");
    }
}
