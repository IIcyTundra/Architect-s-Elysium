using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsConfig : MonoBehaviour
{
    public Slider Master, Music, SFX;
    public AudioMixer audioMixer;


    void Start()
    {
        if(PlayerPrefs.GetInt("set first time volume") == 0){
            PlayerPrefs.SetInt("set first time volume",1);
            Debug.Log("Check");
            Master.value = .5f;
            Music.value = .5f;
            SFX.value = .5f;
        }else{
            Master.value = PlayerPrefs.GetFloat("MasterVolume");
            Music.value = PlayerPrefs.GetFloat("MusicVolume");
            SFX.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    }
    
    public void SetMasterVolume(){
        SetVolume("MasterVolume", Master.value);
    }

    public void SetMusicVolume(){
        SetVolume("MusicVolume", Music.value);
    }

    public void SetSFXVolume(){
        SetVolume("SFXVolume", SFX.value);
    }

    void SetVolume(string name, float value)
    {
        float vol = Mathf.Log10(value) * 20;
        if(value == 0)
        {
            vol = -80;
        }

        audioMixer.SetFloat(name, vol);
        PlayerPrefs.SetFloat(name, vol);
    }
}
