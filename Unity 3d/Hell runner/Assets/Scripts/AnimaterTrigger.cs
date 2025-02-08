using System;
using UnityEngine;

public class AnimaterTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private const string hitString = "Hit";
    const string jumpString = "Jump";
    float waitingTime = 1f;
    float curretnTime = 0f;

    private void Update()
    {
        curretnTime += Time.deltaTime;
        checkJump();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (curretnTime >= waitingTime)
        {
            animator.SetTrigger(hitString);
            curretnTime = 0;
        }
    }

    void checkJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger(jumpString);
        }
    }
}
