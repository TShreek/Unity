using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeLoader : MonoBehaviour
{
    IEnumerator loadScene(string sceneName)
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Main Menu");
    }
}
