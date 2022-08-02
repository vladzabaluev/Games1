using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform MuzzlePoint;
    private PlayerInput playerInput;
    private InputAction i_touch;
    private InputAction i_shot;
    private Camera mainCamera;

    private BulletPooler bulletPooler;

    private void Awake()
    {
        playerInput = new PlayerInput();
        mainCamera = Camera.main;

        playerInput.Player.Enable();
        i_touch = playerInput.Player.StartTouch;
        i_shot = playerInput.Player.Shot;

        i_touch.started += Shoot;

        GameManager.OnGameIsStart.AddListener(ActivateControls);
        GameManager.OnGameIsStop.AddListener(DeactivateControls);
    }

    private void Start()
    {
        bulletPooler = BulletPooler.Instance;
    }

    private void ActivateControls()
    {
        i_shot.Enable();
        i_touch.Enable();
    }

    private void OnEnable()
    {
        ActivateControls();
    }

    private void OnDisable()
    {
        DeactivateControls();
    }

    private void DeactivateControls()
    {
        i_shot.Disable();

        i_touch.Disable();
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        Ray ray = mainCamera.ScreenPointToRay(i_shot.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out RaycastHit hittedThing))
        {
            Vector3 mouseWorldPosition = hittedThing.point;
            Vector3 target = mouseWorldPosition - MuzzlePoint.position;

            bulletPooler.Spawn(MuzzlePoint.position, Quaternion.LookRotation(target));
            // bulletPooler.SpawnFromPool(MuzzlePoint.position, mouseWorldPosition);
        }
    }
}