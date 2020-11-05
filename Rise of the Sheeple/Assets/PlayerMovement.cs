/****
Author: Ben Clark
Using video series "Unity Tutorial - 2D Side Scroller (Super Platformer Bros),
done by Lets Make A Game Together channel. 
Also used "2D Side Scroller MOVEMENT in Unity (BEGINNER FRIENDLY)" by BMo channel. 
​
****/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public int playerSpeed = 30;
    public int playerJumpPower = 1300;
    public float moveX = 0;//Used to determine velocity in the x direction

    public bool facingRight = false;//Might need to be set to false. Can change in the GUI of unity properties. 
    
    private bool isJumping = false;//Not used since we are using isGrounded to prevent multi-jump. 
    // public bool isGrounded;
    // public Transform groundCheck; //Check if radius of character is touching a ground object.
    // public LayerMask groundObjects;//This layer is how the character knows what objects can be jumped off of.
    // public float checkRadius;//Might need a value. Instructions unclear on how to get this to work.

    
    /* These functions aren't currently being used.

    void Update()
    {

    }
    */

    // Using FixedUpdate b/c we are relying on physics calculations done by RigidBody
    // and this lessens the load on the CPU
    private void FixedUpdate()
    {
        //Check if grounded
        // isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);

        controller.Move(moveX * Time.fixedDeltaTime, false, isJumping);

        PlayerMove();
    }

    void PlayerMove()
    {
        //Controls
        moveX = Input.GetAxisRaw("Horizontal") * playerSpeed;//Side movement, default mapped to arrow and WASD keys. 

        animator.SetFloat("Speed", Mathf.Abs(moveX)); 

        if(Input.GetButtonDown ("Jump"))//Can only jump when touching a ground object. Prevents multi-jumping.
        {
            isJumping = true;
            Jump();
            isJumping = false;
        }
    

        //PlayerDirection
        if((moveX < 0) && (facingRight == false))
        {
            FlipPlayer();
        }
        else if ((moveX > 0) && (facingRight == true))
        {
            FlipPlayer();
        }


        //Physics modifications
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);


        //Animations?
    }

    void FlipPlayer()//This flips the sprite automatically when facing a different direction.
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Jump()
    {
            GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
    }
}