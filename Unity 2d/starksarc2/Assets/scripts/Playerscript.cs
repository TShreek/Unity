using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerscript : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 10f;
    Vector2 minBound;
    Vector2 maxBound;
    [SerializeField] float paddingL = 1.5f, paddingR = 1.5f, paddingT = 3f, paddingB = 2f;
    Shoot shoot;

    // Start is called before the first frame update
    void Start()
    {
        shoot = GetComponent<Shoot>();
        InItBound(); // Call this to set up the camera bounds
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    void InItBound()
    {
        Camera mainCam = Camera.main;
        minBound = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = mainCam.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void movePlayer()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;

        // Calculate new position
        Vector3 newPos = new Vector3();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + paddingL, maxBound.x - paddingR);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + paddingB, maxBound.y - paddingT);

        // Set the player's position to the clamped position
        transform.position = newPos;
    }

    void OnFire(InputValue value)
    {
        if (shoot != null)
        {
            shoot.isFiring = value.isPressed;
        }
    }

    // This is called when movement input is received
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    // Detect collision with the power-ups
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ensure tag comparisons are case-sensitive
        if (other.CompareTag("fire"))
        {
            StartCoroutine(TemporaryFireRateBoost());
            Destroy(other.gameObject); // Corrected to use 'other'
            Debug.Log("Fire power-up touched");
        }
        else if (other.CompareTag("speed"))
        {
            StartCoroutine(TemporarySpeedBoost()); // Fixed the coroutine call
            Destroy(other.gameObject); // Corrected to use 'other'
            Debug.Log("Speed power-up touched");
        }
    }

    IEnumerator TemporarySpeedBoost()
    {
        float originalSpeed = moveSpeed; // Save original speed
        moveSpeed *= 1.5f; // Increase speed to 1.5x

        yield return new WaitForSeconds(5f); // Wait for 5 seconds

        moveSpeed = originalSpeed; // Revert speed back to original
        Debug.Log("Speed boost ended, reverted to original speed.");
    }

    IEnumerator TemporaryFireRateBoost()
    {
        float originalFireRate = shoot.GetFireRate(); // Save the original fire rate
        shoot.SetFireRate(0.1f); // Set fire rate to 0.1

        yield return new WaitForSeconds(5f); // Wait for 5 seconds

        shoot.SetFireRate(originalFireRate); // Reset to original fire rate
        Debug.Log("Fire rate boost ended, reverted to original fire rate.");
    }
}
