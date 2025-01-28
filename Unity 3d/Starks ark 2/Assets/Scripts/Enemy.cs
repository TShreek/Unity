using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private ParticleSystem blastEffect;
    ScoreManager scoreManager;
    [SerializeField] private int scoreValue = 20;
    private void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>(); 
    }

    private void OnParticleCollision(GameObject other)
    {
        health -= 1;
        //Debug.Log("COLLISION WITH " + other.gameObject.name + " Health " + health);
        if (health <= 0)
        {
            DestroyObject();
        }

    }

    void DestroyObject()
    {
        scoreManager.addScore(scoreValue);
        if (blastEffect != null)
        {
            //Debug.Log("Blast effect called");
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