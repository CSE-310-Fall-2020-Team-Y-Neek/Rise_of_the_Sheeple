using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Movement : MonoBehaviour
{

    public int playerSpeed = 10;
    public bool facingRight = true;
    public int playerJumpPower = 1300;
    public float moveX;

    // Start is called before the first frame update
    /*
    void Start()
    {
        
    }
    */

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

    }

    void PlayerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        //Animations?

        //PlayerDirection
        if((moveX < 0.0f) && (facingRight == false))
        {
            FlipPlayer ();
        }
        else if ((moveX > 0.0f) && (facingRight == true))
        {
            FlipPlayer();
        }
        //Physics should already be taken care of

    }

    void FlipPlayer()
    {

    }

    void Jump()
    {

    }
}
