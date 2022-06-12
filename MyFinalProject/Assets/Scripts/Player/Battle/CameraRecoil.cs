using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRecoil : MonoBehaviour
{
    private Vector2 targetRotation;
    private Vector2 currentRotation;

    //  private float targetX, targetY;

    private CinemachineRecomposer currentVirtualCameraPatametrs;

    [SerializeField] private float recoilX;
    [SerializeField] private float recoilY;
    // [SerializeField] private float recoilZ;

    [SerializeField] private float snappiness;
    [SerializeField] private float returnSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        currentVirtualCameraPatametrs = Camera.main.GetComponent<CinemachineBrain>()
            .ActiveVirtualCamera.VirtualCameraGameObject
            .GetComponent<Cinemachine.CinemachineVirtualCamera>().GetComponent<CinemachineRecomposer>();
    }

    // Update is called once per frame
    private void Update()
    {
        targetRotation = Vector2.Lerp(targetRotation, Vector2.zero, returnSpeed * Time.deltaTime);
        Debug.Log(targetRotation);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.fixedDeltaTime);
        Debug.Log(currentRotation);
        currentVirtualCameraPatametrs.m_Tilt = currentRotation.x;
        currentVirtualCameraPatametrs.m_Pan = currentRotation.y;
    }

    public void RecoilFire()
    {
        targetRotation = new Vector2(Random.Range(-recoilX, recoilX), Random.Range(-recoilY, recoilY));
        Debug.Log(targetRotation);
    }
}