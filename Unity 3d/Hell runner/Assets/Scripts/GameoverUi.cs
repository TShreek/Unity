using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI coinText;

    private void Start()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        int lastCoins = PlayerPrefs.GetInt("LastCoins", 0);

        scoreText.text = "Score: " + lastScore;
        highScoreText.text = "High Score: " + highScore;
        coinText.text = "Coins: " + lastCoins;
    }
}