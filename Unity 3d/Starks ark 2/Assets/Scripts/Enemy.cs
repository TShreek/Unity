using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem blastEffect;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("COLLISION WITH " + other.gameObject.name);

        if (blastEffect != null)
        {
            Debug.Log("Blast effect called");
            // Instantiate the particle system
            ParticleSystem instantiatedEffect = Instantiate(blastEffect, transform.position + new Vector3(0, 0, -1f), Quaternion.identity);

            // Explicitly call Play() to ensure it starts
            instantiatedEffect.Play();

            // Optional: Destroy the particle system after it has finished playing
            Destroy(instantiatedEffect.gameObject, instantiatedEffect.main.duration);
        }

        // Destroy the enemy
        Destroy(this.gameObject);
    }
}