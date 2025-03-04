using UnityEngine;

public class Coin : Pickup
{
   // private int coinsCollected = 0;
    ScoreKeeper scoreKeeper;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        if (scoreKeeper == null)
        {
            Debug.LogError("No ScoreKeeper found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void onPickup()
    {
       scoreKeeper.addCoin();
    }
    
}
