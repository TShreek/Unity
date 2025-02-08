using System;
using UnityEngine;

public class AnimaterTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private const string hitString = "Hit";
    float waitingTime = 1f;
    float curretnTime = 0f;

    private void Update()
    {
        curretnTime += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (curretnTime >= waitingTime)
        {
            animator.SetTrigger(hitString);
            curretnTime = 0;
        }
    }
}
