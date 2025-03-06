using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMain : MonoBehaviour
{
    private int score = 1;
    private int coins = 0;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI CoinText;
    ScoreKeeper scoreKeeper;
    private Player _player;
    
    private float currentHealth;
    [SerializeField] Slider healthSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = FindFirstObjectByType<Player>();
        if (_player == null)
        {
            Debug.LogError("Player object not found");
        }
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        if (scoreKeeper == null)
        {
            Debug.LogError("ScoreKeeper not found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            currentHealth = _player.GetHealth();
            setHealth();
        }
        if (scoreKeeper != null)
        {
            UpdateScore();
            UpdateCoins();
        }
    }

    private void setHealth()
    {
        healthSlider.value = currentHealth;
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
