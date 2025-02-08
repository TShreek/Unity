using UnityEngine;

public class AnimatorTrigger : MonoBehaviour 
{
    [SerializeField] private Animator animator;
    private const string hitTrigger = "Hit";
    private const string jumpTrigger = "Jump";
    
    private float waitingTime = 1f;
    private float currentTime = 0f;
    
    private void Update()
    {
        currentTime += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space))
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
                animator.SetTrigger(hitTrigger);
                currentTime = 0f;
            }
        }
    }
    
    private void TriggerJump()
    {
        animator.SetTrigger(jumpTrigger);
    }
}