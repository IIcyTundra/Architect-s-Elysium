using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlideController : MonoBehaviour
{
    Player3D_Controller PC_Ref;


    private void Start()
    {
        PC_Ref = GetComponent<Player3D_Controller>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(PC_Ref.SlideKey) && (PC_Ref.horizontalInput != 0 || PC_Ref.verticalInput != 0))
            StartSlide();

        if (Input.GetKeyUp(PC_Ref.SlideKey) && PC_Ref.IsSliding)
            StopSlide();
    }

    private void FixedUpdate()
    {
        if(PC_Ref.IsSliding)
        {
            SlidingMovement();
        }
    }
    private void StartSlide()
    {
        PC_Ref.IsSliding = true;

        PC_Ref.ccP.height = 1;
        PC_Ref.camAnim.speed = 0f;
        PC_Ref.rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

        PC_Ref.SlideTimer = PC_Ref.MaxSlideTime;
    }

    private void SlidingMovement()
    {
        Vector3 InputDirection = PC_Ref.orientation.forward * PC_Ref.verticalInput + PC_Ref.orientation.right * PC_Ref.horizontalInput;

        if(!PC_Ref.OnSlope() || PC_Ref.rb.velocity.y > -0.1f)
        {
            PC_Ref.rb.AddForce(InputDirection.normalized * PC_Ref.SlideForce, ForceMode.Force);

            PC_Ref.SlideTimer -= Time.deltaTime;
        }

        else
        {
            PC_Ref.rb.AddForce(PC_Ref.GetSlopeDir(InputDirection) * PC_Ref.SlideForce, ForceMode.Force);
        }

        if (PC_Ref.SlideTimer <= 0)
            StopSlide();
    }

    private void StopSlide()
    {
        PC_Ref.IsSliding = false;
        PC_Ref.camAnim.speed = 1f;
        PC_Ref.ccP.height = 2;
    }
}
