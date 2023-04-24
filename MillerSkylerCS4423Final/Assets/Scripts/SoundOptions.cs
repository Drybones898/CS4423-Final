using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundOptions : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider ambientSlider;

    void Start()
    {

        if(PlayerPrefs.GetInt("set first time volume") == 0) {
            PlayerPrefs.SetInt("set first time volume", 1);
            masterSlider.value = 0.5f;
            musicSlider.value = 0.5f;
            sfxSlider.value = 0.25f;
            ambientSlider.value = 0.25f;
        } else {
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            ambientSlider.value = PlayerPrefs.GetFloat("AmbientVolume");
        }
    }

    public void SetVolume(string name, float value) {
        float volume = Mathf.Log10(value) * 20;
        if (value == 0) {
            volume = -80;
        }
        audioMixer.SetFloat(name, volume);
        PlayerPrefs.SetFloat(name, value);
    }

    public void SetMasterVolume() {
        SetVolume("MasterVolume", masterSlider.value);
    }

    public void SetMusicVolume() {
        SetVolume("MusicVolume", musicSlider.value);
    }

    public void SetSFXVolume() {
        SetVolume("SFXVolume", sfxSlider.value);
    }

    public void SetAmbientVolume() {
        SetVolume("AmbientVolume", ambientSlider.value);
    }

    void Update()
    {
        
    }
}
