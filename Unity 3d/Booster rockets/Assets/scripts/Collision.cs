using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    [SerializeField]
    float reloadDelay = 1f;
    [SerializeField]
    AudioClip successEffect;
    [SerializeField]
    AudioClip deathEffect;
    [SerializeField]
    ParticleSystem success;
    [SerializeField]
    ParticleSystem death;
    movement player;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<movement>();
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Debug.Log("RESPAWN !!");
                player.Kill();
                death.Play();
                audioSource.PlayOneShot(deathEffect);
                StartCoroutine(LoadScene(reloadDelay,0));
                break;
            case "Wall":
                StartCoroutine(stop());
                break;
            case "Friendly":
                Debug.Log(" NO PROBLEM !!");
                break;
            case "Fuel":
                Debug.Log("Fuel up !!");
                break;
            case "NextLevel":
                Debug.Log("NEXT LEVEL !!");
                success.Play();
                audioSource.PlayOneShot(successEffect);
                StartCoroutine(LoadScene(reloadDelay, 1));
                    break;
            default:
                Debug.Log("OBJECT NOT TAGGED");
                break;
        }
    }

    IEnumerator LoadScene(float delay, int delta)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Get the current scene build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene by incrementing the build index
        SceneManager.LoadScene((currentSceneIndex + delta)%4);
    }
    IEnumerator stop()
    {
        player.Kill();
        yield return new WaitForSeconds(0.3f);
        player.antiKill();
    }
}
