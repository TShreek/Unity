using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] healthScript playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    ScoreKeeper scoreKeeper;
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        healthSlider.maxValue = playerHealth.getHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth.getHealth();
        scoreText.text = "Score: " + scoreKeeper.getScore().ToString();
        timeText.text = "Time Elapsed : " + Time.time.ToString("F3");
    }
}
