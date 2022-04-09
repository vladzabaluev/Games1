using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _anim;
    private PlayerMovement _playerMovement;
    private CharacterController _playerController;
    private NewPlayerInputSystem _input;

    private int _IDSpeed;
    private int _IDJump;
    private int _IDGrounded;
    private int _IDFreeFall;

    private float _maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerController = GetComponent<CharacterController>();
        _input = GetComponent<NewPlayerInputSystem>();

        _maxSpeed = _playerMovement.SprintSpeed;
        AssignAnimationIDs();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveSpeed = new Vector2(_playerController.velocity.x, _playerController.velocity.z);
        _anim.SetFloat(_IDSpeed, moveSpeed.magnitude / _maxSpeed);

        //GetInfoFromMovement();
    }


    void AssignAnimationIDs()
    {
        _IDSpeed = Animator.StringToHash("Speed");
        _IDJump = Animator.StringToHash("Jump");
        _IDGrounded = Animator.StringToHash("Grounded");
        _IDFreeFall = Animator.StringToHash("Free fall");
    }

    void GetInfoFromMovement()
    {
        _anim.SetBool(_IDGrounded, _playerMovement.Grounded);
        _anim.SetBool(_IDFreeFall, _playerMovement.a_freeFall);
        _anim.SetBool(_IDJump, _playerMovement.a_jump);
    }
}
