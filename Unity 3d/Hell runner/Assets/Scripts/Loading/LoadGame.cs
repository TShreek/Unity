using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    IEnumerator loadScene(string sceneName)
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(sceneName);
    }
    public void loadNextScene()
    {
        StartCoroutine(loadScene("Main Scene"));
    }
}
