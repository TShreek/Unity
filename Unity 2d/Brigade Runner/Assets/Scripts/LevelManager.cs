using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // This method starts the coroutine to wait and load a scene
    public void LoadSceneAfterDelay(string sceneName, float waitTime)
    {
        StartCoroutine(WaitAndLoad(sceneName, waitTime));
    }

    // Coroutine to wait and load the scene
    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(delay);

        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }

    // Example method to quit the game (if needed)
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting.");
    }
    public void loadTutorial(){
        LoadSceneAfterDelay("Level 0", 0.5f);
    }
    public void loadGame(){
        LoadSceneAfterDelay("Level 1", 0.5f);
    }

}
