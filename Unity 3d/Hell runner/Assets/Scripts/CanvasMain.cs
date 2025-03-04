using TMPro;
using UnityEngine;

public class CanvasMain : MonoBehaviour
{
    private int score = 1;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI CoinText;
    Coin coin;
    ScoreKeeper scoreKeeper;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        if (scoreKeeper == null)
        {
            Debug.LogError("ScoreKeeper not found in the scene!");
        }
        coin  = FindFirstObjectByType<Coin>();
        if (coin == null)
        {
            Debug.LogError("Coin script not found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreKeeper != null)
        {
            score = scoreKeeper.getScore();
            ScoreText.text = "Score : " + score.ToString();
        }
    }
}
