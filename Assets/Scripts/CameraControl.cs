using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl instance;
    private CinemachineVirtualCamera cinemachineCamera;
    private CinemachineBasicMultiChannelPerlin noise;
    private void Awake()
    {
        instance = this;
        cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
        noise = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        StopShaking();
    }
    public void ShakeCamera(float intensity, float time)
    {
        noise.m_AmplitudeGain = intensity;
        Invoke(nameof(StopShaking), time);
    }
    private void StopShaking()
    {
        noise.m_AmplitudeGain = 0f;
    }
}
