using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    public void SetLevel(float sliderVal)
    {
        mixer.SetFloat("Music", Mathf.Log10(sliderVal) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderVal);
    }
}
