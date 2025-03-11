using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = FindFirstObjectByType<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No audio source found by Game over scene script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tryAgain()
    {
        StartCoroutine(LoadLevel("Main Scene", 0.2f));
    }
    public void loadMainMenu()
    {
        StartCoroutine(LoadLevel("Main Menu", 0.5f));
    }

    IEnumerator LoadLevel(string levelName, float delay)
    {
        if(audioSource != null){audioSource.Stop();}
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(levelName);
    }
}
