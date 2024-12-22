using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private ParticleSystem finishEffect;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        // Cache the AudioSource component for efficiency
        audioSource = GetComponent<AudioSource>();

        // Check if the ParticleSystem is assigned
        if (finishEffect == null)
        {
            Debug.LogError("Finish effect particle system is not assigned.");
        }

        // Check if the AudioSource is assigned
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is not assigned.");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayFinishEffects();
            Invoke("RestartGame", 2f);
        }
    }

    private void PlayFinishEffects()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (finishEffect != null)
        {
            finishEffect.Play();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
