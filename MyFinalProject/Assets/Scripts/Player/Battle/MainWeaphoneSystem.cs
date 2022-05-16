using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MainWeaphoneSystem : MonoBehaviour
{
    public GameObject[] weaphones;

    public Weaphone[] wStates;

    private float indexCurWeaphone = 0;
    public GameObject currentWeaphone;
    private Weaphone curWStats;
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
        for (int j = 0; j < weaphones.Length; j++)
        {
            wStates[j].StartLVL();
            weaphones[j].SetActive(false);
        }
        currentWeaphone = weaphones[(int)indexCurWeaphone];
        currentWeaphone.SetActive(true);
        curWStats = wStates[(int)indexCurWeaphone];
        GlobalEventManager.SendBulletAmountChanged(curWStats);
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
        if (curWStats.shootingType == Weaphone.ShootingType.Hold)
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
        //
        currentWeaphone.SetActive(false);
        currentWeaphone = weaphones[(int)indexCurWeaphone];
        curWStats = wStates[(int)indexCurWeaphone];
        currentWeaphone.SetActive(true);
        //
        GlobalEventManager.SendBulletAmountChanged(curWStats);
    }

    private void SwitchFirst(InputAction.CallbackContext obj)
    {
        if (currentWeaphone != weaphones[0])
        {
            currentWeaphone.SetActive(false);
            currentWeaphone = weaphones[0];
            currentWeaphone.SetActive(true);
            curWStats = wStates[0];
            GlobalEventManager.SendBulletAmountChanged(curWStats);
        }
    }

    private void SwitchSecond(InputAction.CallbackContext obj)
    {
        if (currentWeaphone != weaphones[1])
        {
            //currentWeaphone = weaphones[1];
            //GetComponentInChildren<MeshRenderer>().material.color = currentWeaphone.weaphoneColor;
            //GlobalEventManager.SendBulletAmountChanged(currentWeaphone);
            currentWeaphone.SetActive(false);
            currentWeaphone = weaphones[1];
            currentWeaphone.SetActive(true);
            curWStats = wStates[1];
            GlobalEventManager.SendBulletAmountChanged(curWStats);
        }
    }

    private void Shoot()
    {
        RaycastHit hittedThings;
        if (curWStats.currentBulletInClip <= 0)
        {
            Reload();
        }
        else
        {
            if (Time.time >= nextTimeShot)
            {
                if (curWStats.bulletPerSecond != 0)
                    nextTimeShot = Time.time + 1 / curWStats.bulletPerSecond;
                curWStats.currentBulletInClip--;
                if (Physics.Raycast(shootingPoint.transform.position, shootingPoint.transform.forward, out hittedThings))
                {
                    Debug.Log(hittedThings.transform.name);
                    if (hittedThings.transform.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
                    {
                        enemyStats.TakeDamage(curWStats.Damage);
                        //Сделать чтобы не менялась переменная, а что-то адекватное(смотри NPS_Idle)
                        //подумать над информацией хранящейся просто в нпс_стейт, возможно,
                        //переменной ставить значение стоппингдистанс
                        enemyStats.transform.GetComponent<NPS_IdleState>().ShootedByPlayer = true;
                    }
                }
                GlobalEventManager.SendBulletAmountChanged(curWStats);
            }
        }
    }

    private void OnReload(InputAction.CallbackContext obj)
    {
        Reload();
    }

    private void Reload()
    {
        if (curWStats.currentAllBullet > 0)
        {
            int bulDiffrence = curWStats.bulInСlip - curWStats.currentBulletInClip;
            if (bulDiffrence > curWStats.currentAllBullet)
            {
                curWStats.currentBulletInClip += curWStats.currentAllBullet;
                curWStats.currentAllBullet = 0;
            }
            else
            {
                curWStats.currentBulletInClip = curWStats.bulInСlip;
                curWStats.currentAllBullet -= bulDiffrence;
            }
            Debug.Log(curWStats.currentAllBullet);
        }
        GlobalEventManager.SendBulletAmountChanged(curWStats);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(shootingPoint.transform.position, shootingPoint.transform.forward * 100);
    }
}