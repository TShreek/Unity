using UnityEngine;

public class AnimatorTrigger : MonoBehaviour 
{
    [SerializeField] private Animator animator;
    [SerializeField] private CapsuleCollider playerCollider;  // Reference to player's collider

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
        if (collision.gameObject.CompareTag("Obstacle"))
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
        
        playerCollider.enabled = false; // Temporarily disable collider

        // Re-enable collider after a short time (0.3s to 0.5s)
        Invoke(nameof(ResetCollider), 0.4f);
    }

    private void ResetCollider()
    {
        playerCollider.enabled = true; // Re-enable collider
        isJumping = false;
    }
}