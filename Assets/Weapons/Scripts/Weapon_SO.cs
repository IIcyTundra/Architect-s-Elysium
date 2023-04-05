using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(fileName = "Weapon Base", menuName = "Create Scriptable Object/Weapon")]
public class Weapon_SO : ScriptableObject
{

    #region Variables
    public AudioClip[] shootSounds;
    public AudioClip[] reloadSounds;
    public GameObject Weapon_Obj;
    public GameObject Weapon_Bullet;
    public GameObject Weapon_BHole;
    public GameObject MuzzleFlash;
    [HideInInspector] public Camera PlayerCam;
    public string Weapon_Effect;
    public string Weapon_Name = "Hellwalker";
    public int Weapon_ID = 1; //ID in Weapon Dictionary
    public float Weapon_Range = 5f;
    public int Weapon_Ammo_Mag = 48; //Max ammo in mag 
    public float Weapon_DMG = 20; //This is PER BULLET
    public int Weapon_Bull_Per_Tap = 8; 
    public bool FullAutoToggle;
    public float Weapon_Spread = 0.4f; //Bullet Spread
    public float Weapon_Reload_Speed = 1f;
    public float Weapon_TBShots = 0.2f; //Time Between Each Shot
    public float Weapon_TBShooting = 0.2f;
    public float ShootForce, UpwardForce;

    #endregion
}