using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameSession : MonoBehaviour
{
    public int lives = 3;
    public int coins;
    ScenePersists scenePersists;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI coinsText;

    // Start is called before the first frame update
    private void Awake()
    {
        scenePersists = FindObjectOfType<ScenePersists>();
        updateLivesText();
        coins = 0;
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("CURRENT INDEX : " + currentIndex);
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        // Update lives and coins text only if they are changed (for performance)
        updateLivesText();
        updateCoinsText();
    }

    private void updateCoinsText()
    {
        coinsText.text = "Coins: " + coins;
    }

    public void processPlayerDeath()
    {
        Debug.Log("PROCESS DEATH CALLED");
        if (lives > 1)
        {
            takeLife();
        }
        else
        {
            coins = 0;
            resetGameSession();
            scenePersists.destroyScenePersists();
        }
    }

    private void resetGameSession()
    {
        SceneManager.LoadScene("Level 0");
        Destroy(gameObject);
    }

    private void takeLife()
    {
        lives--;
        updateLivesText();
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    void updateLivesText()
    {
        livesText.text = lives.ToString();
    }

    // Method to update coins
    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("COINS COLLECTED: " + coins);
        updateCoinsText(); // Update the UI after adding coins
    }
}
