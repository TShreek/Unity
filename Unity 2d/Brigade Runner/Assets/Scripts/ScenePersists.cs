using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersists : MonoBehaviour
{
    GameSession gameSession;
    void Awake()
    {
        // Start is called before the first frame update
        int numScenePersists = FindObjectsOfType<GameSession>().Length;
        if (numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void destroyScenePersists()
    {
        Destroy(gameObject);
    }

}
