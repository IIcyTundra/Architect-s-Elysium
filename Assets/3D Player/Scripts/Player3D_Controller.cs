using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player3D_Controller : MonoBehaviour
{
    #region Player Variables

    [Header("Movement")]
    public Player_SO PlayerDataRef; //Reference to base player stats
    public bool CanJump; //Checks if we can jump
    public Animator camAnim; //Camera Animator
    float PlayerGroundCheck; //Checks if the player touches the ground

    [Header("Keybinds")]
    public KeyCode JumpKey = KeyCode.Space; 
    public KeyCode CrouchKey = KeyCode.LeftShift;
    public KeyCode SlideKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float PlayerHeight; //Capsule Collider height
    public LayerMask whatIsGround; 
    [SerializeField] bool grounded; //Checks if we're on the ground
    [SerializeField] bool IsWalking; //Checks if we're walking

    [Header("Input Detection")]
    [HideInInspector] public float horizontalInput;
    [HideInInspector] public float verticalInput;
    Vector3 MoveDirection;

    [Header("Misc")]
    [HideInInspector] public CapsuleCollider ccP; //Capsule Collider reference
    public Transform orientation; //Player's look direction
    [HideInInspector] public Rigidbody rb; 

    [Header("Slope Handle")]
    public float MaxSlopeAngle; //Max angle that the player can walk up a slope
    [HideInInspector] private RaycastHit SlopeTouched; //Checks if we're touching a slope
    [HideInInspector] private bool LeaveSlope; //Checks if we're leaving a slope
    public bool IsSliding; //Checks if we're sliding

    [Header("Sliding")]
    public float MaxSlideTime; 
    public float SlideForce;
    public float SlideTimer;
    public float CurrHealth;

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        CanJump = true;
        CurrHealth = PlayerDataRef.Health;
        ccP = GetComponent<CapsuleCollider>();
        
    }
    private void Update()
    {   
        //Check to see if we're touching the ground
        grounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.2f, whatIsGround);
        
        MyInput();
        SpeedControl();
        WalkAnim();
        StateHandler();
        camAnim.SetBool(name: "IsWalking", IsWalking);
        camAnim.SetBool(name: "IsSliding", IsSliding);
        

        //Handle Player Drag and AnimCheck
        if (grounded)
        {
            rb.drag = PlayerDataRef.GroundDrag;
            
        }
        else{
            rb.drag = 0;
        }

        
    }

    private void FixedUpdate()
    {
        MovePlayer(); 
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(JumpKey) && CanJump && grounded)
        {
            Debug.Log("Jumping");
            CanJump = false;
            Jump();
            Invoke(nameof(ResetJump),PlayerDataRef.JumpCooldown);
        }
        
        if(Input.GetKeyDown(CrouchKey))
        {
            ccP.height = 1;
            camAnim.speed = 0.5f;
            rb.AddForce(Vector3.down *5f, ForceMode.Impulse);
        }

        if(Input.GetKeyUp(CrouchKey))
        {
           camAnim.speed = 1f;
           ccP.height = 2;
        }

    }

    private void StateHandler()
    { 
        if(IsSliding)
        {
            PlayerDataRef.MState = Player_SO.MovementState.sliding;

            if(OnSlope() && rb.velocity.y < 0.1f)
            {
                PlayerDataRef.NeededMoveSpeed = PlayerDataRef.PlayerSlideSpeed;
            }
            else
            {
                PlayerDataRef.NeededMoveSpeed = PlayerDataRef.PlayerWalkSpeed;
            }
        }
        else if(Input.GetKey(CrouchKey))
        {
            PlayerDataRef.MState = Player_SO.MovementState.crouching;
            PlayerDataRef.NeededMoveSpeed = PlayerDataRef.PlayerCrouchSpeed;
        }
        else if(grounded)
        {
            PlayerDataRef.MState = Player_SO.MovementState.walking;
            PlayerDataRef.NeededMoveSpeed = PlayerDataRef.PlayerWalkSpeed;
        }
        else if(!grounded)
        {
            PlayerDataRef.MState = Player_SO.MovementState.air;
        }

        if(Mathf.Abs(PlayerDataRef.NeededMoveSpeed - PlayerDataRef.PrevMoveSpeed) >4f && PlayerDataRef.PlayerSpeed != 0)
        {
            StopAllCoroutines();
            StartCoroutine(MomentumCalculator());
        }
        else
        {
            PlayerDataRef.PlayerSpeed = PlayerDataRef.NeededMoveSpeed;
        }

        PlayerDataRef.PrevMoveSpeed = PlayerDataRef.NeededMoveSpeed;
    }

    #region Movement Functions

    private void MovePlayer()
    {
        //Move Dir
        MoveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(OnSlope() && !LeaveSlope)
        {
            //Debug.Log("AHHHHHHH");
            rb.AddForce(GetSlopeDir(MoveDirection) * PlayerDataRef.PlayerSpeed * 20f, ForceMode.Force);
            if(rb.velocity.y > 0)
                
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }
        //Check Ground
        else if(grounded)
            rb.AddForce(MoveDirection.normalized * PlayerDataRef.PlayerSpeed * 10f, ForceMode.Force);

        //Check Air
        else if(!grounded)
            rb.AddForce(MoveDirection.normalized * PlayerDataRef.PlayerSpeed * 10f * PlayerDataRef.AirMultiplier, ForceMode.Force);
        
        rb.useGravity = !OnSlope();
    
    
    }

    private void SpeedControl()
    {

        //Slowdown Player On Slope
        if(OnSlope() && !LeaveSlope)
        {
            if(rb.velocity.magnitude > PlayerDataRef.PlayerSpeed)
                rb.velocity = rb.velocity.normalized * PlayerDataRef.PlayerSpeed;
        }
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            if(flatVel.magnitude > PlayerDataRef.PlayerSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * PlayerDataRef.PlayerSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
        

    }

    private void WalkAnim()
    {
        if(MoveDirection.magnitude > 0.1f && grounded)
        {
            IsWalking = true;
        }
        else
        {
            IsWalking = false;
        }
    }

    private void Jump()
    {
        LeaveSlope = true;
        //Resets Y Velocity to insure jump height consistency
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        rb.AddForce(transform.up * PlayerDataRef.JumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        CanJump = true;
        LeaveSlope = false;
    }

    
    
    #endregion

    #region Physics Check

    public bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out SlopeTouched, PlayerHeight * 0.5f + 0.3f))
        {
            float Angle = Vector3.Angle(Vector3.up, SlopeTouched.normal);
            return Angle < MaxSlopeAngle && Angle !=0;
        }

        return false;
    }

    public Vector3 GetSlopeDir(Vector3 Direction)
    {
        return Vector3.ProjectOnPlane(Direction, SlopeTouched.normal).normalized;
    }

    private IEnumerator MomentumCalculator()
    {
        float time = 0;
        float diff = Mathf.Abs(PlayerDataRef.NeededMoveSpeed - PlayerDataRef.PlayerSpeed);
        float StartVal = PlayerDataRef.PlayerSpeed;

        while(time < diff)
        {
            PlayerDataRef.PlayerSpeed = Mathf.Lerp(StartVal, PlayerDataRef.NeededMoveSpeed, time/diff);
            
            if(OnSlope())
            {
                float SlopeAngle =  Vector3.Angle(Vector3.up, SlopeTouched.normal);
                float SlopeAngleIncrease = 1 + (SlopeAngle /90f);

                time += Time.deltaTime * PlayerDataRef.SPDMULT * PlayerDataRef.SLPMULT *SlopeAngleIncrease;
            }
            else
            {
                time += Time.deltaTime * PlayerDataRef.SPDMULT;
            }
                

            yield return null;

            
        }

        PlayerDataRef.PlayerSpeed = PlayerDataRef.NeededMoveSpeed;

    }

    #endregion

   
}
