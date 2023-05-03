using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "MusicReference", menuName = "Create Music Prefab/Music")]
public class Music_SO : ScriptableObject
{

    public AudioMixer MusicVolume, SFXVolume, MasterVolume;

}
