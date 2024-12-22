using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioSource crashAudio;

    private void Start()
    {
        // Check if the ParticleSystem is assigned
        if (crashEffect == null)
        {
            Debug.LogError("Crash effect particle system is not assigned.");
        }

        // Check if the AudioSource is assigned
        if (crashAudio == null)
        {
            Debug.LogError("Crash audio source is not assigned.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            PlayCrashEffects();
            Invoke("ReloadScene", 0.15f);
        }
        else
        {
            Debug.Log("Something went wrong!! ");
        }
    }

    private void PlayCrashEffects()
    {
        if (crashAudio != null)
        {
            crashAudio.Play();
        }

        if (crashEffect != null)
        {
            crashEffect.Play();
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
