using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //horizontal movement
    public float speed; //can be changed in unity editor
    private float horizontalMove;
    private Rigidbody2D rb;
    private float prevHorizontalMove;

    //jumping
    private bool isGrounded = false;
    public float jumpForce; //can be changed in unity editor

    //animation
    public Animator animator { get; private set; }

    public bool paused = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        prevHorizontalMove = 0;
    }

    void Update()
    {
        horizontalMove = InputManager.instance.moveInput.x;
        if(horizontalMove != prevHorizontalMove)
        {
            animator.SetTrigger("Move");
        }

        //jumps
        if(InputManager.instance.jumpInput && isGrounded && !paused)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", true);
            animator.SetTrigger("Jump");
        }

        //animations
        animator.SetFloat("xVelocity", horizontalMove);
        animator.SetFloat("yVelocity", rb.velocity.y);

        if(horizontalMove < .1f && horizontalMove > -.1f)
        {
            animator.SetBool("NotMoving", true);
        }
        else
        {
            animator.SetBool("NotMoving", false);
        }

        prevHorizontalMove = horizontalMove;
    }

    void FixedUpdate()
    {
        if(!paused)
        {
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void OnCollisionStay2D(Collision2D other) 
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
