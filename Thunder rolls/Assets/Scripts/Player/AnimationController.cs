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
        _anim.SetFloat(_IDSpeed, _playerController.velocity.magnitude / _maxSpeed);
        if (_playerMovement.Grounded)
        {
            _anim.SetBool(_IDJump, false);
            _anim.SetBool(_IDFreeFall, false);
        }
        else
        {
            if(_input.jump)
            {
                _anim.SetBool(_IDJump, true);
            }
           
        }
    }


    void AssignAnimationIDs()
    {
        _IDSpeed = Animator.StringToHash("Speed");
        _IDJump = Animator.StringToHash("Jump");
        _IDGrounded = Animator.StringToHash("Grounded");
        _IDFreeFall = Animator.StringToHash("Free fall");
    }
}
