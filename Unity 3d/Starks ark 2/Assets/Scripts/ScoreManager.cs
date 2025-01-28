using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
    }

    public void addScore(int toAdd)
    {
        score += toAdd;
        Debug.Log(score);
    }

    void updateScore()
    {
        scoreText.text = "Current Score : " + score.ToString();
    }
}
