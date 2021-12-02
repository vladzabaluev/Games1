using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private List<Animator>_anim = new List<Animator>();
    [Range(0,2)]
    [SerializeField] private float _speed;
    private bool _isActive=true;   
    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {
            for (int i = 0; i < _anim.Count; i++)
            {
                _anim[i].SetFloat("Multypli", _speed);
            }
        }
    }

    public void IsActiveAnim() 
    {
        _isActive = !_isActive;
    }
}
