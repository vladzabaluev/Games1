using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerInputSystem : MonoBehaviour
{
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;

    PlayerInput playerInputActions;
    InputAction _moveIA;
    InputAction _lookIA;
    InputAction _jumpIA;
    InputAction _sprintIA;

    private void Awake()
    {
        playerInputActions = new PlayerInput();
    }

    private void OnEnable()
    {
        _moveIA = playerInputActions.Player.Move;

        _lookIA = playerInputActions.Player.Look;

        _jumpIA = playerInputActions.Player.Jump;
        _jumpIA.started += DoJump;

        _sprintIA = playerInputActions.Player.Sprint;
        _sprintIA.started += StartSprint;
        _sprintIA.canceled += StopSprint;

        playerInputActions.Player.Enable();
     
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }
    private void DoJump(InputAction.CallbackContext obj)
    {
        jump = _jumpIA.IsPressed();
    }

    private void StartSprint(InputAction.CallbackContext callbackContext)
    {
        sprint = true;
    }

    private void StopSprint(InputAction.CallbackContext obj)
    {
        sprint = false;
    }


    // Update is called once per frame
    void Update()
    {
        move = _moveIA.ReadValue<Vector2>();
        look = _lookIA.ReadValue<Vector2>();
    }

    
}
