using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{ 
    public void loadLevel0()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void loadLevel1()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void loadLevel2()
    {
        SceneManager.LoadScene("Scene3");
    }
    public void loadMM()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
