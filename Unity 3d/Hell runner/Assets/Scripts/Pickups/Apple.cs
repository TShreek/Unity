using UnityEngine;

public class Apple : Pickup
{
    private Player player;
    private int healthBoost = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player == null)
        {
            Debug.LogError("player not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    protected override void onPickup()
    {
        player.addHealth(healthBoost);
    }
}
