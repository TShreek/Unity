using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    float waitTime = .6f;

    public void loadGame()
    {
        StartCoroutine(waitAndLoad("Game", 0.2f));
    }
    
    public void EnterCredits(){
        StartCoroutine(waitAndLoad("Credits", 0.2f));
        
    }

    public void exitCredits(){
        StartCoroutine(waitAndLoad("MM",0f));
        Debug.Log("EXIT CREDITS called");
    }
    public void EndGame()
    {
        StartCoroutine(waitAndLoad("GameOver", waitTime)); // Removed the semicolon inside
    }

    public void loadMM()
    {
        SceneManager.LoadScene("MM");
    }

    public void quitGame()
    {
        Application.Quit();
    }
    public void howToPlay(){
        StartCoroutine(waitAndLoad("howToPlay", 0.2f));
    }

    IEnumerator waitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);  // Corrected to WaitForSeconds with capital W
        SceneManager.LoadScene(sceneName);
    }
}
