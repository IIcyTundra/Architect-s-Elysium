using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D pBody;
    public float walkSpeed;
    public Animator animator;
    Vector2 direction;



    // Update is called once per frame
    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        // Debug.Log(direction.x);
        // Debug.Log(direction.y);
        AnimState();   
    }

    private void FixedUpdate()
    {
        pBody.velocity = direction * walkSpeed; 
    }


    private void AnimState()
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }



}
