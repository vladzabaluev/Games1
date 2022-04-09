using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class WeaphoneSystem : MonoBehaviour
{
    //public List<Weaphone> weaphones;
    public Weaphone[] weaphones;

    private float indexCurWeaphone = 0;
    public Weaphone currentWeaphone;

    private PlayerInputActions p_Input;
    private InputAction i_switchWeaphone;
    private InputAction i_reload;
    private InputAction i_shoot;
    private InputAction i_switchToFirst;
    private InputAction i_switchToSecond;

    private float nextTimeShot = 0;

    public UnityEvent<Weaphone> e_ChangeText;

    // Start is called before the first frame update
    private void Awake()
    {
        p_Input = new PlayerInputActions();
    }

    private void Start()
    {
        foreach (var weap in weaphones)
        {
            weap.StartLVL();
        }
        currentWeaphone = weaphones[(int)indexCurWeaphone];
        GetComponentInChildren<MeshRenderer>().material.color = currentWeaphone.weaphoneColor;
        WeaphoneTextUpdate();
    }

    private void OnEnable()
    {
        i_switchWeaphone = p_Input.Player.SwitchWeaphone;
        i_reload = p_Input.Player.Reload;
        i_shoot = p_Input.Player.Attack;
        i_switchToFirst = p_Input.Player.SwitchToFirst;
        i_switchToSecond = p_Input.Player.SwitchToSecond;
        i_switchWeaphone.performed += OnWeaphoneSwitch;
        i_reload.performed += OnReload;
        i_switchToFirst.performed += SwitchFirst;
        i_switchToSecond.performed += SwitchSecond;

        i_switchToFirst.Enable();
        i_switchToSecond.Enable();
        i_switchWeaphone.Enable();
        i_reload.Enable();
        i_shoot.Enable();
    }

    private void OnDisable()
    {
        i_switchToFirst.Disable();
        i_switchToSecond.Disable();
        i_switchWeaphone.Disable();
        i_reload.Disable();
        i_shoot.Disable();
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentWeaphone.shootingType == Weaphone.ShootingType.Hold)
        {
            if (i_shoot.inProgress)
            {
                Shoot();
            }
        }
        else
        {
            if (i_shoot.triggered)
            {
                Shoot();
            }
        }
    }

    public void OnWeaphoneSwitch(InputAction.CallbackContext callbackContext)
    {
        float wheelInputValue = i_switchWeaphone.ReadValue<float>();
        wheelInputValue = wheelInputValue / Mathf.Abs(wheelInputValue);
        indexCurWeaphone += wheelInputValue;
        if (indexCurWeaphone < 0)
        {
            indexCurWeaphone = weaphones.Length - 1;
        }
        if (indexCurWeaphone > weaphones.Length - 1)
        {
            indexCurWeaphone = 0;
        }
        currentWeaphone = weaphones[(int)indexCurWeaphone];
        GetComponentInChildren<MeshRenderer>().material.color = currentWeaphone.weaphoneColor;
        WeaphoneTextUpdate();
    }

    private void SwitchFirst(InputAction.CallbackContext obj)
    {
        if (currentWeaphone != weaphones[0])
        {
            currentWeaphone = weaphones[0];
            GetComponentInChildren<MeshRenderer>().material.color = currentWeaphone.weaphoneColor;
            WeaphoneTextUpdate();
        }
    }

    private void SwitchSecond(InputAction.CallbackContext obj)
    {
        if (currentWeaphone != weaphones[1])
        {
            currentWeaphone = weaphones[1];
            GetComponentInChildren<MeshRenderer>().material.color = currentWeaphone.weaphoneColor;
            WeaphoneTextUpdate();
        }
    }

    private void Shoot()
    {
        RaycastHit hittedThings;
        if (currentWeaphone.currentBulletInClip <= 0)
        {
            Reload();
        }
        else
        {
            if (Time.time >= nextTimeShot)
            {
                if (currentWeaphone.bulletPerSecond != 0) nextTimeShot = Time.time + 1 / currentWeaphone.bulletPerSecond;
                currentWeaphone.currentBulletInClip--;
                if (Physics.Raycast(transform.position, transform.forward, out hittedThings))
                {
                    Debug.Log(hittedThings.transform.name);
                }
                WeaphoneTextUpdate();
            }
        }
    }

    private void OnReload(InputAction.CallbackContext obj)
    {
        Reload();
    }

    private void Reload()
    {
        if (currentWeaphone.currentAllBullet > 0)
        {
            int bulDiffrence = currentWeaphone.bulIn�lip - currentWeaphone.currentBulletInClip;
            if (bulDiffrence > currentWeaphone.currentAllBullet)
            {
                currentWeaphone.currentBulletInClip += currentWeaphone.currentAllBullet;
                currentWeaphone.currentAllBullet = 0;
            }
            else
            {
                currentWeaphone.currentBulletInClip = currentWeaphone.bulIn�lip;
                currentWeaphone.currentAllBullet -= bulDiffrence;
            }
            Debug.Log(currentWeaphone.currentAllBullet);
        }
        WeaphoneTextUpdate();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * currentWeaphone.shootingRange);
    }

    private void WeaphoneTextUpdate()
    {
        e_ChangeText.Invoke(currentWeaphone);
    }
}