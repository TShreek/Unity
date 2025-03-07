using System;
using UnityEngine;

public class FenceCollisionHandler : MonoBehaviour
{
    public bool enabled = true;
    private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        if (player == null)
        {
            Debug.LogError("Player not found by fence collision handler");
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("enabled = " + enabled);
        if (enabled)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                player.DealDamage(10);
            }
        }
    }
}
