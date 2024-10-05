using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footAnimation : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        StartCoroutine(GetAnimator());
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Jumpable"))
        {
            if(animator != null)
            {
                animator.SetBool("isJumping", false);
            }
        }
    }

    IEnumerator GetAnimator()
    {
        yield return new WaitForSeconds(0.1f);
        Movement movement = GetComponentInParent<Movement>();
        if(movement == null)
        {
            Debug.LogError("Movement script not found");
        }

        animator = movement.animator;
        if(animator == null)
        {
            Debug.LogError("Animator not found");
        }
    }

}
