using UnityEngine;
using System;
using System.Collections;

public class PlatformerMovement : MonoBehaviour
{

    // Use this for initialization
    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    private bool grounded = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxis("Horizontal");
        var velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveSpeed * moveX;
        if (Mathf.Abs(velocity.x) > Math.Abs(moveX * moveSpeed))
        {
            velocity.x = moveX * moveSpeed;
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
        }
    }


    public void Grounded()
    {
        grounded = true;
    }

    public void NotGrounded()
    {
        grounded = false;
    }
}



