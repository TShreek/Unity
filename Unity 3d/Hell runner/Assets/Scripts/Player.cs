using System;
using System.Collections;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float minX = -5f; // Left boundary
    [SerializeField] private float maxX = 5f;  // Right boundary
    
    [Header("Speed camera movement")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float normalFOV = 60f;   // Default FOV
    [SerializeField] private float maxFOV = 80f;      // FOV when moving fast
    [SerializeField] private float fovChangeSpeed = 5f;
    ScoreKeeper scoreKeeper;
    
    [Header("Shake movement")]
    [SerializeField] private float shakeIntensity = 0.1f; // How much the shake moves the camera
    [SerializeField] private float shakeSpeed = 10f;

    [Header("Health")]
    [SerializeField] private float health = 100f;
 
    [Header("Game Over Text")]
    [SerializeField] TextMeshProUGUI gameOverText;
    
    private Vector2 movement = Vector2.zero;
    bool isSprinting = false;
    private Vector3 originalCameraPosition;

    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        originalCameraPosition = mainCamera.transform.localPosition;
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        isSprinting = movement.y > 0; 
    }

    void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(movement.x, 0, movement.y);
        transform.Translate(movementVector * (Time.fixedDeltaTime * movespeed));

        // Clamp position
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Adjust camera FOV based on forward movement
        AdjustCameraFOV();
        ApplyCameraShake();
    }

    void AdjustCameraFOV()
    {
        float targetFOV = normalFOV;

        if (movement.y > 0) // If moving forward
        {
            targetFOV = Mathf.Lerp(mainCamera.fieldOfView, maxFOV, Time.deltaTime * fovChangeSpeed);
            scoreKeeper.DoubleScore();
        }
        else
        {
            targetFOV = Mathf.Lerp(mainCamera.fieldOfView, normalFOV, Time.deltaTime * fovChangeSpeed);
            scoreKeeper.resetScale();
        }

        mainCamera.fieldOfView = targetFOV;
    }
    void ApplyCameraShake()
    {
        if (isSprinting)
        {
            // Generate Perlin noise-based shake
            float shakeX = (Mathf.PerlinNoise(Time.time * shakeSpeed, 0) - 0.5f) * shakeIntensity;
            float shakeY = (Mathf.PerlinNoise(0, Time.time * shakeSpeed) - 0.5f) * shakeIntensity;

            mainCamera.transform.localPosition = originalCameraPosition + new Vector3(shakeX, shakeY, 0);
        }
        else
        {
            // Smoothly reset to the original position when not sprinting
            mainCamera.transform.localPosition = Vector3.Lerp(mainCamera.transform.localPosition, originalCameraPosition, Time.deltaTime * 5f);
        }
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            health = 0; // Prevents negative health
            DisplayGameOverText();
            scoreKeeper.endGame();
            StartCoroutine(loadGameOverScene());
        }
    }

    IEnumerator loadGameOverScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game Over Scene");
    }
    public float GetHealth()
    {
        return health;
    }

    public void addHealth(float amount)
    {
        health += amount;
    }
    
    private void DisplayGameOverText()
    {
        gameOverText.gameObject.SetActive(true); // Show the text
        Debug.Log("Game Over!");
    }
}