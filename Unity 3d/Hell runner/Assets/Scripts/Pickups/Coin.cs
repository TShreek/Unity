using UnityEngine;

public class Coin : Pickup
{
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
        Debug.Log("Coin PICKED U");
    }
}
