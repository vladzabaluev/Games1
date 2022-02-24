using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Moving parameters
    public float MoveSpeed = 5f;
    public float SprintSpeed = 8f;
    public float Acceleration = 10f;
    public float Deceleration = 10f;

    //Rotation parameters
    public float SmoothTime = 0.15f;

    //Jumping parameters
    public float JumpHeight = 1.2f;
    public float Gravity = -15.0f;

    public float JumpTimeout = 0.50f;
    public float FallTimeout = 0.15f;

    //Touch earth parameters
    public bool Grounded = true;
    public float GroundedOffset = -0.2f;
    public float GroundedRadius = 0.20f;
    public LayerMask GroundLayers;

    //Player components
    private CharacterController _playerController;
    private NewPlayerInputSystem _input;
    GameObject _camera;

    //Calculation Parameters:
    //for move
    float _speed;
    float _targetSpeed;
    float _currentHorizontalVelocity;
    //for jump
    float _fallingVelocity;
    float _jumpTimeoutDelta;
    float _fallTimeoutDelta;
    //for rotating
    float _targetRotation;
    float _turnSmoothVelocity;
    Vector3 _targetDirection;

    // Start is called before the first frame update

    private void Awake()
    {
        _camera = Camera.main.gameObject;
    }
    void Start()
    {
        _playerController = GetComponent<CharacterController>();
        _input = GetComponent<NewPlayerInputSystem>();
        //_rotater = GetComponent<PlayerRotater>();


        _jumpTimeoutDelta = JumpTimeout;
        _fallTimeoutDelta = FallTimeout;
    }
    
    // Update is called once per frame
    void Update()
    {
        JumpAndGravity();
        GroundCheck();
        Move();
    }

    void Move()
    {
        _targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed;

        if (_input.move == Vector2.zero) _targetSpeed = 0.0f;

        //about acceleration
        _currentHorizontalVelocity = new Vector3(_playerController.velocity.x, 0, _playerController.velocity.z).magnitude;
        float speedOffset = 0.1f;

        if (_currentHorizontalVelocity < _targetSpeed - speedOffset)
        {
            AcclerationOrDeceleration(Acceleration);
        }
        else if (_currentHorizontalVelocity > _targetSpeed + speedOffset)
        {
            AcclerationOrDeceleration(Deceleration);
        }
        else
        {
            _speed = _targetSpeed;
        }

        //rotate player 
        Vector3 inputDirection = new Vector3(_input.move.x, 0, _input.move.y).normalized;

        if (_input.move != Vector2.zero)
        {
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _turnSmoothVelocity, SmoothTime);
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

        _targetDirection = Quaternion.Euler(0, _targetRotation, 0) * Vector3.forward;

        _playerController.Move(_targetDirection.normalized * (_targetSpeed * Time.deltaTime) + new Vector3(0f, _fallingVelocity, 0f) * Time.deltaTime);
    }
    void AcclerationOrDeceleration(float SpeedChangeRate)
    {
        _speed= Mathf.Lerp(_currentHorizontalVelocity, _targetSpeed * _input.move.magnitude, Time.deltaTime * SpeedChangeRate);
        _speed = _speed * 1000 / 1000;
    }
    void JumpAndGravity()
    {
        if (Grounded)
        {
            _fallTimeoutDelta = FallTimeout;
            if (_fallingVelocity < 0.0f)
            {
                _fallingVelocity = -2f;
            }

            if (_input.jump && _jumpTimeoutDelta <= 0.0f)
            {
                _fallingVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);
            }

            if (_jumpTimeoutDelta >= 0.0f)
            {
                _jumpTimeoutDelta -= Time.deltaTime;
            }
        }
        else
        {
            _jumpTimeoutDelta = JumpTimeout;

            if (_fallTimeoutDelta >= 0.0f)
            {
                _fallTimeoutDelta -= Time.deltaTime;
            }

            _input.jump = false;
        }

        _fallingVelocity += Gravity * Time.deltaTime;
    }
    void GroundCheck()
    {
        Vector3 groundCheckPosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
        Grounded = Physics.CheckSphere(groundCheckPosition, GroundedRadius, GroundLayers.value);
    }

    private void OnDrawGizmosSelected()
    {
        Color green = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color red = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        if (Grounded) Gizmos.color = green;
        else Gizmos.color = red;

        // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z), GroundedRadius);
    }
}
