using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    private PlayerInputActions p_Input;

    private InputAction i_reload;
    private InputAction i_attack;

    private float ShootingRange = 5f;
    //Количество патрон, ренжа, урон, скорострельность
    // Start is called before the first frame update
    private void Awake()
    {
        p_Input = new PlayerInputActions();
    }

    private void Update()
    {
        if (i_attack.inProgress)
        {
            Shoot();
        }
    }

    private void OnEnable()
    {
        i_attack = p_Input.Player.Attack;
        i_reload = p_Input.Player.Reload;
        
        i_reload.started += Reload;
        p_Input.Player.Enable();
    }

    private void Reload(InputAction.CallbackContext obj)
    {
        Debug.Log("Reload");
    }

    private void Shoot(/*InputAction.CallbackContext obj*/)
    {
        //Debug.Log("Shoot");
        RaycastHit hittedThings;

        if (Physics.Raycast(transform.position, transform.forward, out hittedThings, ShootingRange))
        Debug.Log(hittedThings.transform.name);
    }

    private void OnDisable()
    {
        p_Input.Player.Disable();
    }
}
