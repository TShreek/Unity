using UnityEngine;

public class AnimatorTrigger : MonoBehaviour 
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider playerCollider;  

    private const string hitTrigger = "Hit";
    private const string jumpTrigger = "Jump";

    private float waitingTime = 1f;  
    private float currentTime = 0f;
    private bool isJumping = false;
    private bool canTrip = true; // Controls when tripping is allowed

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            TriggerJump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ensure "Hit" animation is only triggered if player is NOT mid-air
        if (!isJumping && canTrip && collision.gameObject.CompareTag("Obstacle"))  
        {
            if (currentTime >= waitingTime)
            {
                Debug.Log("Collided with: " + collision.gameObject.name);
                animator.SetTrigger(hitTrigger);
                currentTime = 0f;
            }
        }
    }

    private void TriggerJump()
    {
        isJumping = true;
        canTrip = false; // Disable tripping right after a jump
        animator.SetTrigger(jumpTrigger);

        // Temporarily disable collider to avoid unwanted collisions
        playerCollider.enabled = false;

        // Re-enable everything after jump duration
        Invoke(nameof(ResetAfterJump), 0.3f);
    }

    private void ResetAfterJump()
    {
        playerCollider.enabled = true;  // Enable collider again
        isJumping = false;

        // Delay the ability to trip again slightly after landing
        Invoke(nameof(EnableTripping), 0.2f);
    }

    private void EnableTripping()
    {
        canTrip = true;
    }
}