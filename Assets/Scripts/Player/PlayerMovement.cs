using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public float moveSpeed = 5f; // Speed of player movement

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
        // Reset all movement booleans to false
        animator.SetBool("isWalkingNorth", false);
        animator.SetBool("isWalkingEast", false);
        animator.SetBool("isWalkingSouth", false);
        animator.SetBool("isWalkingWest", false);

        // Prioritize vertical movement
        if (moveDirection.y > 0) // Moving North
        {
            animator.SetBool("isWalkingNorth", true);
        }
        else if (moveDirection.y < 0) // Moving South
        {
            animator.SetBool("isWalkingSouth", true);
        }
        else if (moveDirection.x > 0) // Moving East
        {
            animator.SetBool("isWalkingEast", true);
        }
        else if (moveDirection.x < 0) // Moving West
        {
            animator.SetBool("isWalkingWest", true);
        }

        // Set Idle to true only if no other movement booleans are true
        bool isWalking = animator.GetBool("isWalkingNorth") || 
                         animator.GetBool("isWalkingEast") || 
                         animator.GetBool("isWalkingSouth") || 
                         animator.GetBool("isWalkingWest");

        animator.SetBool("isIdle", !isWalking);
    }
}
