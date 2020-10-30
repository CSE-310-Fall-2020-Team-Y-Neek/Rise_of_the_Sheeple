/****
Author: Ben Clark
Using video series "Unity Tutorial - 2D Side Scroller (Super Platformer Bros),
done by Lets Make A Game Together channel. 

****/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Movement : MonoBehaviour
{
    
    public int playerSpeed = 10;
    public int playerJumpPower = 1300;

    public bool facingRight = true;
    private bool isJumping = false;
    public bool isGrounded;
    public Transform groundCheck; //needed for not being able to multi-jump
    public LayerMask groundObjects;
    public float moveX;
    public float checkRadius;

    // Start is called before the first frame update
    
    void Start()
    {
        
    }
    

    // Using FixedUpdate b/c we are relying on physics calculations done by RigidBody
    // and this lessens the load on the CPU
    private void FixedUpdate()
    {
        //Check if grounded
        isGrounded = Physics2D.overlapCircle(groundCheck.position, checkRadius, groundObjects);

        PlayerMove();
    }

    void PlayerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown ("Jump") && isGrounded)
        {
            isJumping = true;
            Jump();
            isJumping = false;
        }
        //Animations?

        //PlayerDirection
        if((moveX < 0.0f) && (facingRight == false))
        {
            FlipPlayer();
        }
        else if ((moveX > 0.0f) && (facingRight == true))
        {
            FlipPlayer();
        }
        //Physics should already be taken care of
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void FlipPlayer()
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
