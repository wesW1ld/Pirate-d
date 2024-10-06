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

    [SerializeField] GameObject fireDown;
    SpriteRenderer fireDownSprite;

    //pausing for win barrier and animation
    public bool paused = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        prevHorizontalMove = -1;
        fireDownSprite = fireDown.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(!paused)
        {
            horizontalMove = InputManager.instance.moveInput.x;
        }
        else
        {
            horizontalMove = 0;
        }

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

        if(prevHorizontalMove != 0){
            animator.SetFloat("PrevInput", prevHorizontalMove);
        }


        if(rb.velocity.y < -15){
            Debug.Log("Going Down:" + rb.velocity.y);
            fireDownSprite.color = new Color(fireDownSprite.color.r,fireDownSprite.color.b,fireDownSprite.color.g, -rb.velocity.y - 15);
        }
        else if (rb.velocity.y > -10 && rb.velocity.y < 0){
            fireDownSprite.color = new Color(fireDownSprite.color.r,fireDownSprite.color.b,fireDownSprite.color.g, 0);
        }

        if(rb.velocity.y == 0){
            fireDownSprite.color = new Color(fireDownSprite.color.r,fireDownSprite.color.b,fireDownSprite.color.g, 0);
        }

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
