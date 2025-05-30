using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeLoader : MonoBehaviour
{
    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Main Menu");
    }

    private void Start()
    {
        StartCoroutine(loadScene());
    }
}
