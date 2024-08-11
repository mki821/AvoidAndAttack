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
        //카메라 가져오는건 원하는 방식으로 고쳐서 써
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
            //cameraPerlin.m_AmplitudeGain = amplitude * value; 이거 대신 사용할 수 있는 코드야
            //Lerp는 많이 쓰니까 한 번 공부해봐

            yield return null; //한 프레임 쉬겠다는 뜻
        }

        cameraPerlin.m_AmplitudeGain = 0;
    }
}
