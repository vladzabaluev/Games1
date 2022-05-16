using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class WeaphoneSystem : MonoBehaviour
{
    public Weaphone[] weaphonesStats;

    private float indexCurWeaphone = 0;
    public Weaphone currentWeaphoneStats;
    public GameObject shootingPoint;

    private PlayerInputActions p_Input;
    private InputAction i_switchWeaphone;
    private InputAction i_reload;
    private InputAction i_shoot;
    private InputAction i_switchToFirst;
    private InputAction i_switchToSecond;

    private float nextTimeShot = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        p_Input = new PlayerInputActions();
    }

    private void Start()
    {
        foreach (var weap in weaphonesStats)
        {
            weap.StartLVL();
        }
        currentWeaphoneStats = weaphonesStats[(int)indexCurWeaphone];
        GetComponentInChildren<MeshRenderer>().material.color = currentWeaphoneStats.weaphoneColor;
        GlobalEventManager.SendBulletAmountChanged(currentWeaphoneStats);
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
        if (currentWeaphoneStats.shootingType == Weaphone.ShootingType.Hold)
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
            indexCurWeaphone = weaphonesStats.Length - 1;
        }
        if (indexCurWeaphone > weaphonesStats.Length - 1)
        {
            indexCurWeaphone = 0;
        }
        currentWeaphoneStats = weaphonesStats[(int)indexCurWeaphone];
        GetComponentInChildren<MeshRenderer>().material.color = currentWeaphoneStats.weaphoneColor;
        GlobalEventManager.SendBulletAmountChanged(currentWeaphoneStats);
    }

    private void SwitchFirst(InputAction.CallbackContext obj)
    {
        if (currentWeaphoneStats != weaphonesStats[0])
        {
            currentWeaphoneStats = weaphonesStats[0];
            GetComponentInChildren<MeshRenderer>().material.color = currentWeaphoneStats.weaphoneColor;
            GlobalEventManager.SendBulletAmountChanged(currentWeaphoneStats);
        }
    }

    private void SwitchSecond(InputAction.CallbackContext obj)
    {
        if (currentWeaphoneStats != weaphonesStats[1])
        {
            currentWeaphoneStats = weaphonesStats[1];
            GetComponentInChildren<MeshRenderer>().material.color = currentWeaphoneStats.weaphoneColor;
            GlobalEventManager.SendBulletAmountChanged(currentWeaphoneStats);
        }
    }

    private void Shoot()
    {
        RaycastHit hittedThings;
        if (currentWeaphoneStats.currentBulletInClip <= 0)
        {
            Reload();
        }
        else
        {
            if (Time.time >= nextTimeShot)
            {
                if (currentWeaphoneStats.bulletPerSecond != 0) nextTimeShot = Time.time + 1 / currentWeaphoneStats.bulletPerSecond;
                currentWeaphoneStats.currentBulletInClip--;
                if (Physics.Raycast(shootingPoint.transform.position, shootingPoint.transform.forward, out hittedThings))
                {
                    Debug.Log(hittedThings.transform.name);
                    if (hittedThings.transform.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
                    {
                        enemyStats.TakeDamage(currentWeaphoneStats.Damage);
                        //Сделать чтобы не менялась переменная, а что-то адекватное(смотри NPS_Idle)
                        //подумать над информацией хранящейся просто в нпс_стейт, возможно,
                        //переменной ставить значение стоппингдистанс
                        enemyStats.transform.GetComponent<NPS_IdleState>().ShootedByPlayer = true;
                    }
                }
                GlobalEventManager.SendBulletAmountChanged(currentWeaphoneStats);
            }
        }
    }

    private void OnReload(InputAction.CallbackContext obj)
    {
        Reload();
    }

    private void Reload()
    {
        if (currentWeaphoneStats.currentAllBullet > 0)
        {
            int bulDiffrence = currentWeaphoneStats.bulInСlip - currentWeaphoneStats.currentBulletInClip;
            if (bulDiffrence > currentWeaphoneStats.currentAllBullet)
            {
                currentWeaphoneStats.currentBulletInClip += currentWeaphoneStats.currentAllBullet;
                currentWeaphoneStats.currentAllBullet = 0;
            }
            else
            {
                currentWeaphoneStats.currentBulletInClip = currentWeaphoneStats.bulInСlip;
                currentWeaphoneStats.currentAllBullet -= bulDiffrence;
            }
            Debug.Log(currentWeaphoneStats.currentAllBullet);
        }
        GlobalEventManager.SendBulletAmountChanged(currentWeaphoneStats);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(shootingPoint.transform.position, shootingPoint.transform.forward * 100);
    }
}