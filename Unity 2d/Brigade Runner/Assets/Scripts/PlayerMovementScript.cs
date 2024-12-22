using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    Vector2 moveInput;

    float jumpForce = 6f;
    float moveSpeed = 3f;
    [SerializeField] float climbSpeed = 1f; // Speed at which the player climbs
    [SerializeField] Transform groundCheck;
    float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask stairsLayer;  // Layer for stairs
    [SerializeField] Sprite deadSprite;
    [SerializeField] GameObject bullets;
    [SerializeField] Transform gun;

    SpriteRenderer playerBody;
    Rigidbody2D rgbd;
    Animator animator;

    bool isGrounded;
    bool isOnStairs;
    bool isClimbing;
    bool isRolling;
    bool isAlive = true;

    void Start()
    {
        isAlive = true;
        rgbd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerBody = GetComponent<SpriteRenderer>();

        // Optional: Set gravity scale if needed
        rgbd.gravityScale = 1f;
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        isOnStairs = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, stairsLayer);

        // Movement and sprite flipping
        if (isAlive)
        {
            run();
            flipSprite();


            // Climb stairs logic
            if (isOnStairs && Keyboard.current.eKey.isPressed) // Using 'E' key to climb stairs
            {
                isClimbing = true;
                climbStairs();
            }
            else
            {
                isClimbing = false;
                rgbd.gravityScale = 1f; // Reset gravity scale when not climbing
            }

            // Rolling logic
            if (Keyboard.current.cKey.isPressed && !isRolling && animator.GetBool("isrRunning"))
            {
                Roll();
            }

            animator.SetBool("isClimbing", isClimbing);
            animator.SetBool("isRolling", isRolling);
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (isAlive)
        {
            if (value.isPressed && isGrounded)
            {
                rgbd.velocity = new Vector2(rgbd.velocity.x, 0); // Reset vertical velocity
                rgbd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    void flipSprite()
    {
        bool playerMovingHorizontal = Mathf.Abs(rgbd.velocity.x) > .1f;
        if (playerMovingHorizontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(rgbd.velocity.x), 1f);
        }
        else
        {
            // Ensure the player stands upright if not moving
            transform.localScale = new Vector2(transform.localScale.x, 1f);
        }
    }

    void run()
    {
        bool playerMovingHorizontal = Mathf.Abs(rgbd.velocity.x) > .1f;
        Vector2 playerVelocity = new Vector2(moveInput.x, rgbd.velocity.y);

        rgbd.velocity = new Vector2(playerVelocity.x * moveSpeed, rgbd.velocity.y);

        animator.SetBool("isrRunning", playerMovingHorizontal);

        // Ensure the player is upright
        if (isGrounded)
        {
            transform.rotation = Quaternion.identity; // Reset rotation to default
        }
    }

    void climbStairs()
    {
        // Reduce gravity while climbing to make it easier to climb stairs
        rgbd.gravityScale = 0.2f;

        // Handle climbing movement
        Vector2 climbVelocity = new Vector2(moveInput.x * moveSpeed, climbSpeed); // Move up while climbing
        rgbd.velocity = climbVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.layer == LayerMask.NameToLayer("Hazards"))
        {
            Debug.Log("YOU ARE DEAD!!");
            Invoke("die", 1f);
        }
    }

    public void die()
    {
        if (!isAlive) return; // Prevent re-triggering death logic

        isAlive = false;
        playerBody.sprite = deadSprite;
        animator.SetBool("isAlive", false); // Optionally update animator to reflect death state

        // Ensure GameSession exists before calling processPlayerDeath
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            gameSession.processPlayerDeath();
        }
        else
        {
            Debug.LogWarning("No GameSession found in the scene.");
        }

        // Optionally: Disable further player controls or actions
        // e.g., Disable components or set additional flags
    }



    void Roll()
    {
        if (isAlive)
        {
            // Trigger roll animation
            isRolling = true;
            animator.SetBool("isRolling", true);

            // Optionally: Perform any additional rolling logic (e.g., apply force or change player state)

            // Reset rolling state after animation completes
            StartCoroutine(EndRollAnimation());
        }
    }

    IEnumerator EndRollAnimation()
    {
        // Wait for the duration of the roll animation
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        isRolling = false;
        animator.SetBool("isRolling", false);
    }

    void OnFire()
    {
        if (isAlive)
        {
            Instantiate(bullets, gun.position, transform.rotation);
        }
        Debug.Log("FIREE!!!");
    }

}
