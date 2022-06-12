using Cinemachine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MainWeaphoneSystem : MonoBehaviour
{
    public GameObject[] weaphones;

    public Weaphone[] wStates;

    private float indexCurWeaphone = 0;
    public GameObject currentWeaphone;
    private Weaphone curWStats;
    public Transform shootingPoint;

    private Camera mainCamera;
    private Cinemachine.CinemachineVirtualCamera _currentVirtualCamera;
    private Animator anim;

    public Image Crosshair;
    public Color HoverColor;
    private Color BaseColor;

    private PlayerInputActions p_Input;
    private InputAction i_switchWeaphone;
    private InputAction i_reload;
    private InputAction i_shoot;
    private InputAction i_zoom;
    private InputAction i_switchToFirst;
    private InputAction i_switchToSecond;

    private float nextTimeShot = 0;
    private RaycastHit hoverThings;

    [SerializeField]
    private float zoomingFOV;

    private float startFOV;
    private float? targetFOV;

    private AudioSource audioSource;

    public LineRenderer lineRenderer;

    private CameraRecoil cameraRecoil;

    // Start is called before the first frame update
    private void Awake()
    {
        p_Input = new PlayerInputActions();
        anim = GetComponent<Animator>();
        audioSource = gameObject.AddComponent<AudioSource>();

        BaseColor = Crosshair.color;

        GlobalEventManager.OnGamePaused.AddListener(DisablePlayerActionMap);
        GlobalEventManager.OnPlayerDead.AddListener(DisablePlayerActionMap);
        GlobalEventManager.OnGameUnpaused.AddListener(EnablePlayerActionMap);

        mainCamera = Camera.main;
        cameraRecoil = GetComponentInParent<CameraRecoil>();
    }

    private void DisablePlayerActionMap()
    {
        p_Input.Player.Disable();
    }

    private void EnablePlayerActionMap()
    {
        p_Input.Player.Enable();
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
        i_zoom = p_Input.Player.Zoom;
        i_zoom.started += ZoomIn;

        i_zoom.canceled += ZoomOut;
        i_switchWeaphone.performed += OnWeaphoneSwitch;
        i_reload.performed += OnReload;
        i_switchToFirst.performed += SwitchFirst;
        i_switchToSecond.performed += SwitchSecond;

        i_switchToFirst.Enable();
        i_switchToSecond.Enable();
        i_switchWeaphone.Enable();
        i_reload.Enable();
        i_shoot.Enable();
        i_zoom.Enable();
    }

    private void OnDisable()
    {
        i_switchToFirst.Disable();
        i_switchToSecond.Disable();
        i_switchWeaphone.Disable();
        i_reload.Disable();
        i_shoot.Disable();
        i_zoom.Disable();
    }

    // Update is called once per frame
    private void Update()
    {
        //if (curWStats.shootingType == Weaphone.ShootingType.Hold)
        //{
        //    if (i_shoot.inProgress)
        //    {
        //        Shoot();
        //    }
        //}
        //else
        //{
        //    if (i_shoot.triggered)
        //    {
        //        Shoot();
        //    }
        //}
        Aiming();
        if (targetFOV != null)
            ZoomUpdater(targetFOV.Value);
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

    //private void Shoot()
    //{
    //    RaycastHit hittedThings;
    //    if (curWStats.currentBulletInClip <= 0)
    //    {
    //        Reload();
    //    }
    //    else
    //    {
    //        if (Time.time >= nextTimeShot)
    //        {
    //            if (curWStats.bulletPerSecond != 0)
    //                nextTimeShot = Time.time + 1 / curWStats.bulletPerSecond;
    //            curWStats.currentBulletInClip--;
    //            if (Physics.Raycast(shootingPoint.transform.position, shootingPoint.transform.forward, out hittedThings))
    //            {
    //                Debug.Log(hittedThings.transform.name);
    //                if (hittedThings.transform.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
    //                {
    //                    enemyStats.TakeDamage(curWStats.Damage);
    //                    //Сделать чтобы не менялась переменная, а что-то адекватное(смотри NPS_Idle)
    //                    //подумать над информацией хранящейся просто в нпс_стейт, возможно,
    //                    //переменной ставить значение стоппингдистанс
    //                    enemyStats.transform.GetComponent<NPS_IdleState>().ShootedByPlayer = true;
    //                }
    //            }

    //            GlobalEventManager.SendBulletAmountChanged(curWStats);
    //        }
    //    }
    //}

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

    private void ZoomIn(InputAction.CallbackContext obj)
    {
        FindCurrentVirtualCamera();
        anim.SetBool("ZoomIn", true);
        startFOV = _currentVirtualCamera.m_Lens.FieldOfView;
        targetFOV = zoomingFOV;
        //_currentVirtualCamera.m_Lens.FieldOfView = zoomingFOV;
    }

    private void ZoomOut(InputAction.CallbackContext obj)
    {
        anim.SetBool("ZoomIn", false);
        targetFOV = startFOV;
        //_currentVirtualCamera.m_Lens.FieldOfView = startFOV;
    }

    private void ZoomUpdater(float targetZoom)
    {
        float speed = 10;
        _currentVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(_currentVirtualCamera.m_Lens.FieldOfView, targetZoom, speed * Time.deltaTime);
    }

    private void FindCurrentVirtualCamera()
    {
        _currentVirtualCamera = Camera.main.GetComponent<CinemachineBrain>()
            .ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    private void Aiming()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = mainCamera.ScreenPointToRay(screenCenterPoint);

        if (Physics.Raycast(ray, out hoverThings))
        {
            if (hoverThings.transform.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
            {
                Crosshair.color = HoverColor;
            }
            else
            {
                Crosshair.color = BaseColor;
            }
        }

        if (curWStats.shootingType == Weaphone.ShootingType.Hold)
        {
            if (i_shoot.inProgress)
            {
                Shoot();
                //StartCoroutine(Shoot());
            }
        }
        else
        {
            if (i_shoot.triggered)
            {
                Shoot();
                //StartCoroutine(Shoot());
            }
        }
    }

    private void Shoot()
    {
        if (curWStats.currentBulletInClip <= 0)
        {
            Reload();
        }
        else
        {
            if (Time.time >= nextTimeShot)
            {
                cameraRecoil.RecoilFire();
                if (curWStats.bulletPerSecond != 0)
                    nextTimeShot = Time.time + 1 / curWStats.bulletPerSecond;
                curWStats.currentBulletInClip--;

                HitCheck();

                GlobalEventManager.SendBulletAmountChanged(curWStats);
                AudioManager.PlaySound(curWStats.ShotSound, audioSource, false, false);

                //lineRenderer.enabled = true;
                //if (hoverThings.transform != null)
                //{
                //    lineRenderer.SetPosition(0, shootingPoint.position);
                //    lineRenderer.SetPosition(1, hoverThings.transform.position);
                //}
                //else
                //{
                //    lineRenderer.SetPosition(0, shootingPoint.position);
                //    lineRenderer.SetPosition(1, /*shootingPoint.position +*/ shootingPoint.forward * 100f);
                //}
            }
        }
        // yield return 0;
        //yield return new WaitForSeconds(0.02f);
        //lineRenderer.enabled = false;
    }

    private void HitCheck()
    {
        if (hoverThings.transform != null)
            if (hoverThings.transform.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
            {
                enemyStats.TakeDamage(curWStats.Damage);
                //Сделать чтобы не менялась переменная, а что-то адекватное(смотри NPS_Idle)
                //подумать над информацией хранящейся просто в нпс_стейт, возможно,
                //переменной ставить значение стоппингдистанс
                enemyStats.transform.GetComponent<NPC_IdleState>().ShootedByPlayer = true;
            }
    }
}