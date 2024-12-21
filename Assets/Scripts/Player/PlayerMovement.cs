using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private float moveSpeed = 3f;

    private Vector2 moveDirection;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for movement (WASD or arrow keys)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Calculate movement direction based on input
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Update Animator parameters based on movement direction
        HandleAnimator();
    }

    void FixedUpdate()
    {
        // Apply the movement to the player using Rigidbody2D for physics-based movement
        rb.linearVelocity = moveDirection * moveSpeed;
    }

    void HandleAnimator()
    {
        // Prioritize vertical movement
        if (moveDirection.y > 0) // Moving North
        {
            animator.SetBool("isNorth", true);
            animator.SetBool("isEast", false);
            animator.SetBool("isSouth", false);
            animator.SetBool("isWest", false);
            
            animator.SetBool("isIdle", false);
        }
        else if (moveDirection.y < 0) // Moving South
        {
            animator.SetBool("isNorth", false);
            animator.SetBool("isEast", false);
            animator.SetBool("isSouth", true);
            animator.SetBool("isWest", false);
            
            animator.SetBool("isIdle", false);
        }
        else if (moveDirection.x > 0) // Moving East
        {
            animator.SetBool("isNorth", false);
            animator.SetBool("isEast", true);
            animator.SetBool("isSouth", false);
            animator.SetBool("isWest", false);
            
            animator.SetBool("isIdle", false);
        }
        else if (moveDirection.x < 0) // Moving West
        {
            animator.SetBool("isNorth", false);
            animator.SetBool("isEast", false);
            animator.SetBool("isSouth", false);
            animator.SetBool("isWest", true);
            
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isIdle", true);
        }
    }
}
