using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText; // Use TextMeshProUGUI if using TextMeshPro
    // public Text scoreText; // Uncomment this line if using the standard Text component
    private int score = 0;

    void Awake()
    {
        // Singleton pattern to ensure only one instance of ScoreManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (scoreText == null)
        {
            // Try to find the score text if it is not assigned in the Inspector
            scoreText = FindObjectOfType<TextMeshProUGUI>();
            
            if (scoreText == null)
            {
                Debug.LogError("ScoreText is not assigned and could not be found in the scene.");
            }
        }
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
