using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D_Controller : MonoBehaviour
{
    #region Player Variables
    [Header("Movement")]
    public Player_SO PlayerDataRef;
    [SerializeField] bool CanJump;
    public Animator camAnim;

    [Header("Keybinds")]
    public KeyCode JumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float PlayerHeight;
    public LayerMask whatIsGround;
    [SerializeField] bool grounded;
    [SerializeField] bool isWalking;
    
    [Header("Misc")]
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 MoveDirection;
    Rigidbody rb;

    [Header("Slope Handle")]
    public float MaxSlopeAngle;
    private RaycastHit SlopeTouched;

    private bool LeaveSlope;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        CanJump = true;
    }

    private void Update()
    {
        //Check to see if we're touching the ground
        grounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.8f, whatIsGround);

        MyInput();
        SpeedControl();
        WalkAnim();
        JumpCheck();
        camAnim.SetBool(name: "isWalking", isWalking);
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

    }

    


    #region Movement Functions
    private void MovePlayer()
    {
        //Move Dir
        MoveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(OnSlope())
        {
            rb.AddForce(GetSlopeDir() * PlayerDataRef.PlayerSpeed * 20f, ForceMode.Force);

            if(rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }
        //Check Ground
        if(grounded)
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
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void Jump()
    {
        LeaveSlope = true;
        //Resets Y Velocity
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

    private void JumpCheck()
    {
        if(Input.GetKey(JumpKey) && CanJump && grounded)
        {
            //Debug.Log("Jumping");
            CanJump = false;
            Jump();
            Invoke(nameof(ResetJump),PlayerDataRef.JumpCooldown);
        }
    }

    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out SlopeTouched, PlayerHeight * 0.8f))
        {
            float Angle = Vector3.Angle(Vector3.up, SlopeTouched.normal);
            return Angle < MaxSlopeAngle && Angle !=0;
        }

        return false;
    }

    private Vector3 GetSlopeDir()
    {
        return  Vector3.ProjectOnPlane(MoveDirection, SlopeTouched.normal).normalized;
    }

    #endregion

}
