using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float range = 2f;
    Vector2 movement;
    Vector3 startPosition;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] float rotSpeed = 20f;
    [SerializeField] float pitchLmit = 20f;
    [SerializeField] float delay = 5f;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        ProcessMovement();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = -movement.y * pitchLmit;
        float rot = -movement.x * rotSpeed;
        Quaternion rotation = Quaternion.Euler(pitch, 0f, rot);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, rotation, delay* Time.deltaTime);
    }

    private void ProcessMovement()
    {
        float xOffset = movement.x * Time.deltaTime * moveSpeed;
        float yOffset = movement.y * Time.deltaTime * moveSpeed;

        // Calculate the new position based on movement
        float newX = transform.localPosition.x + xOffset;
        float newY = transform.localPosition.y + yOffset;

        // Clamp the new position relative to the start position
        newX = Mathf.Clamp(newX, startPosition.x - range, startPosition.x + range);
        newY = Mathf.Clamp(newY, startPosition.y - range, startPosition.y + range);

        // Apply the clamped position
        transform.localPosition = new Vector3(newX, newY, 0f);
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (deathParticles != null)
        {
            Debug.Log("Blast effect called");

            // Instantiate the particle system
            ParticleSystem instantiatedEffect = Instantiate(deathParticles, transform.position + new Vector3(0, 0, -1f), Quaternion.identity);

            // Explicitly play the particle system
            instantiatedEffect.Play();

            // Optional: Destroy the particle system after it has finished playing
            Destroy(instantiatedEffect.gameObject, instantiatedEffect.main.duration);
        }

        // Destroy the player GameObject
        Destroy(this.gameObject);
    }
}
