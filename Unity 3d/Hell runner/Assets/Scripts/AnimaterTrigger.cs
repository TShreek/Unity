using UnityEngine;

public class AnimatorTrigger : MonoBehaviour 
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider playerCollider;  // Single collider

    private const string hitTrigger = "Hit";
    private const string jumpTrigger = "Jump";

    private float waitingTime = 1f;  
    private float currentTime = 0f;
    private bool isJumping = false;

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
        if (!isJumping && collision.gameObject.CompareTag("Obstacle"))  
        {
            if (currentTime >= waitingTime)
            {
                Debug.Log(collision.gameObject.name);
                animator.SetTrigger(hitTrigger);
                currentTime = 0f;
            }
        }
    }

    private void TriggerJump()
    {
        isJumping = true;
        animator.SetTrigger(jumpTrigger);

        // Temporarily disable collider to avoid unwanted collisions
        playerCollider.enabled = false;

        // Disable **this script** so "Hit" animation is never called mid-air
        this.enabled = false;

        // Re-enable everything after 0.3s
        Invoke(nameof(ResetAfterJump), 0.3f);
    }

    private void ResetAfterJump()
    {
        playerCollider.enabled = true;  // Enable collider again
        isJumping = false;

        // Re-enable this script after landing
        this.enabled = true;
    }
}