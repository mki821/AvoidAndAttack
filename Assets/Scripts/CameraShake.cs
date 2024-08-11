using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public float frequency = 3f;
    public float amplitude = 3f;
    public float shakeTime = 1f;

    private CinemachineVirtualCamera vCam;
    private CinemachineBasicMultiChannelPerlin cameraPerlin;

    private void Awake()
    {
        vCam = FindObjectOfType<CinemachineVirtualCamera>();
        //ī�޶� �������°� ���ϴ� ������� ���ļ� ��
        cameraPerlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Start()
    {
        cameraPerlin.m_FrequencyGain = frequency;

        
    }

    public void Shake()
    {
        StartCoroutine(ShakeCam(amplitude, shakeTime));
    }

    IEnumerator ShakeCam(float amplitude, float time)
    {
        float currentTime = 0f;
        float value = 0f;

        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            value = 1 - (currentTime / time);

            cameraPerlin.m_AmplitudeGain = amplitude * value;
            //cameraPerlin.m_AmplitudeGain = Mathf.Lerp(amplitude, 0, currentTime / time);
            //cameraPerlin.m_AmplitudeGain = amplitude * value; �̰� ��� ����� �� �ִ� �ڵ��
            //Lerp�� ���� ���ϱ� �� �� �����غ�

            yield return null; //�� ������ ���ڴٴ� ��
        }

        cameraPerlin.m_AmplitudeGain = 0;
    }
}
