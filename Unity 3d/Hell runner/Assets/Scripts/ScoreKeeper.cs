using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private bool doubleScore = false;
    private int score = 0;
    private int coins = 0;
    private bool isAlive = true;

    public static ScoreKeeper Instance;  // Singleton instance

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Makes this object persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicate instances
        }
    }

    private void Update()
    {
        if (isAlive)
        {
            score += doubleScore ? 2 : 1;
        }
    }

    public void DoubleScore() => doubleScore = true;
    public void resetScale() => doubleScore = false;
    public int getScore() => score;

    public void addCoin()
    {
        if (isAlive) coins++;
    }

    public int getCoins() => coins;

    public void endGame()
    {
        isAlive = false;
        SaveHighScore();  // Save high score when game ends
    }

    private void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
        PlayerPrefs.SetInt("LastScore", score);
        PlayerPrefs.SetInt("LastCoins", coins);
        PlayerPrefs.Save();
    }
}