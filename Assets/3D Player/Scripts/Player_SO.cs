using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Create Scriptable Object/Player")]
public class Player_SO : ScriptableObject
{
    [Header("Player Physics Stats")]
    public float PlayerSpeed; //Current Player Speed
    public float PlayerWalkSpeed; //Player Walk Speed
    public float PlayerCrouchSpeed; //Player Crouch Speed
    public float PlayerSlideSpeed; //Player Slide Speed
    public float NeededMoveSpeed; //Max Move Speed
    public float PrevMoveSpeed;  
    public float SPDMULT; //Speed Increase
    public float SLPMULT; //Slope Increase
    public float GroundDrag;
    public float AirMultiplier;
    public float JumpForce;
    public float JumpCooldown;

    //------------------------------------------------------------------
    
    [Header("PlayerStates")]

    public MovementState MState;
    public enum MovementState
    {
        walking,
        crouching,
        sliding,
        air
    }

    //------------------------------------------------------------------
    
    [Header("Player GP Stats")]

    [Range (0,100)] public int Health;
    public int Currency;
    
    

    
}
