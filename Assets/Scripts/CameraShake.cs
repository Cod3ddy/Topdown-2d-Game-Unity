using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeIntensity = 1f;
    private float shakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmp;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Start()
    {
        StopCameraShake();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            ShakeCamera();
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                StopCameraShake();
            }
        }
    }

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin _cbmp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmp.m_AmplitudeGain = shakeIntensity;
        timer = shakeTime;
    }

    public void StopCameraShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmp.m_AmplitudeGain = 0f;
        timer = 0;
    }
}
