using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //horizontal movement
    public float speed; //can be changed in unity editor
    private float horizontalMove;
    private Rigidbody2D rb;

    //jumping
    private bool isGrounded = false;
    public float jumpForce; //can be changed in unity editor

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = InputManager.instance.moveInput.x;

        if(InputManager.instance.jumpInput && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Jumpable"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Jumpable"))
        {
            isGrounded = false;
        }
    }
}
