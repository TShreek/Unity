using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    string playerTag = "Player";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }
    }
}
