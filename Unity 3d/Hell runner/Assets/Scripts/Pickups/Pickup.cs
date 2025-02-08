using System;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    string playerTag = "Player";
    [SerializeField] float rotationSpeed = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    protected abstract void onPickup();
}
