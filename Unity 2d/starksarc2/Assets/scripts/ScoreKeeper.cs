using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    // Singleton instance
    public static ScoreKeeper instance;

    int score;
    int high_score = 0;

    private void Awake() 
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        // Check if an instance already exists and destroy the new one
        if (instance != null)
        {
            Destroy(gameObject);  // Destroy duplicate instance
        }
        else
        {
            instance = this;  // Set this as the singleton instance
            DontDestroyOnLoad(gameObject);  // Preserve this instance across scenes
        }
    }

    public int getScore()
    {
        return score;
    }

    public void addScore()
    {
        score += 100;
        Debug.Log("Score: " + score);
    }

    public void deductScore()
    {
        if (score >= 50)
        {
            score -= 50;
        }
        else
        {
            score = 0;
        }
    }

    public void resetScore()
    {
        if (score > high_score)  // Fix: High score should update if the current score is higher
        {
            high_score = score;
            Debug.Log("New high score: " + high_score);
        }
        score = 0;
        Debug.Log("Score reset to: " + score);
    }

    public int getHighScore()
    {
        return high_score;
    }
}
