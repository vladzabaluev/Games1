using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotater : MonoBehaviour
{
    public float SmoothTime = 0.15f;
    public float rotation;
    public Vector3 targetDirection;

    float _targetRotation;
    float _turnSmoothVelocity;


    private PlayerInputSystem _input;

    private GameObject _playerCamera;
    private void Awake()
    {
        if (_playerCamera == null)
        {
            _playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerInputSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        Vector3 inputDirection = _input.move.normalized;
        if (inputDirection != Vector3.zero)
        {
            float rotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + _playerCamera.transform.eulerAngles.y;
            _targetRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref _turnSmoothVelocity, SmoothTime);
            transform.rotation = Quaternion.Euler(0f, _targetRotation, 0f);

            targetDirection = Quaternion.Euler(0f, rotation, 0f) * Vector3.forward;
        }
    }
}
