using TMPro;
using UnityEngine;

public class CanvasMain : MonoBehaviour
{
    private int score = 1;
    private int coins = 0;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI CoinText;
    ScoreKeeper scoreKeeper;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        if (scoreKeeper == null)
        {
            Debug.LogError("ScoreKeeper not found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreKeeper != null)
        {
            UpdateScore();
            UpdateCoins();
        }
    }

    private void UpdateCoins()
    {
        coins = scoreKeeper.getCoins();
        CoinText.text = coins.ToString();
    }

    private void UpdateScore()
    {
        score = scoreKeeper.getScore();
        ScoreText.text = "Score : " + score.ToString();
    }
}
