using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Create Scriptable Object/Player")]
public class Player_SO : ScriptableObject
{
    public float PlayerSpeed;
    public float GroundDrag;
    public float AirMultiplier;
    public float JumpForce;
    public float JumpCooldown;
    public int Currency;
    public int Health;
    public int WeaponChoice;
    
}
