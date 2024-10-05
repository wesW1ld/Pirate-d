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

    //animation
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        horizontalMove = InputManager.instance.moveInput.x;

        if(InputManager.instance.jumpInput && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

        animator.SetFloat("xVelocity", transform.position.x);
        animator.SetFloat("yVelocity", transform.position.y);
        animator.SetBool("isJumping", !isGrounded);

        if(horizontalMove < .1f && horizontalMove > -.1f)
        {
            animator.SetBool("NotMoving", true);
        }
        else
        {
            animator.SetBool("NotMoving", false);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Jumpable"))
        {
            isGrounded = true;
        }
    }
}
