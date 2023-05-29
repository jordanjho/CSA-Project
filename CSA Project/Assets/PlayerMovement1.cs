using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{

    public float speed;
    public float Move;

    public float jump;
    private int numOfJumps = 2;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Moving horizontally
        Move = Input.GetAxis("HorizontalWASD");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && numOfJumps > 0)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            Debug.Log("jump");
            numOfJumps--;
        }

        // Crouching
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            rb.gravityScale = 12f;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            rb.gravityScale = 3f;
        }

        // Freeze the rotation
        rb.freezeRotation = true;
    }
///*
    private void OnCollisionEnter2D(Collision2D other) 
    {
        //isJumping = false;
        numOfJumps = 2;
    }
//*/
}

