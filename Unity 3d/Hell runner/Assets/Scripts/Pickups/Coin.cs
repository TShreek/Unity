using UnityEngine;

public class Coin : Pickup
{
    private int coinsCollected = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void onPickup()
    {
        coinsCollected++;
    }

    public int getCoinsCollected()
    {
        return coinsCollected;
    }
}
