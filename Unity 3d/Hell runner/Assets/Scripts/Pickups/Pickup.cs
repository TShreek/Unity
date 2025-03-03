using System;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    private string playerTag = "Player";
    [SerializeField] private float rotationSpeed = 100f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log(other.name);
            onPickup();  // Ensure the abstract method is called
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    protected abstract void onPickup(); // Ensure derived classes implement this
}