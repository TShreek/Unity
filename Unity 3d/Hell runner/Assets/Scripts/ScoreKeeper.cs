using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private bool doubleScore = false;
    private int score = 0;
    private int coins=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doubleScore)
        {
            score += 2;
        }
        else
        {
            score += 1;
        }
    }

    public void DoubleScore()
    {
        doubleScore = true;
    }

    public void resetScale()
    {
        doubleScore = false;
    }
    public int getScore()
    {
        return score;
    }

    public void addCoin()
    {
        coins++;
    }

    public int getCoins()
    {
        return coins;
    }
}
