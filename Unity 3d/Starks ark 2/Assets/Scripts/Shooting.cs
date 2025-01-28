using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float targetDist = 100f;
    [SerializeField] private GameObject[] lasers;
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Transform targetPt;

    private bool isFiring = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null) Debug.LogError("Main Camera not found!");

        if (crosshair == null) Debug.LogError("Crosshair not assigned!");
        if (targetPt == null) Debug.LogError("Target point not assigned!");
        if (lasers == null || lasers.Length == 0) Debug.LogError("Lasers array is empty!");
        
        Cursor.visible = false;
    }

    void Update()
    {
        MoveTargetPoint();
        MoveCrosshair();
        ProcessFiring();
        aimLasers();
    }

    private void MoveTargetPoint()
    {
        Vector3 targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDist);
        targetPt.position = mainCamera.ScreenToWorldPoint(targetPos);
    }

    private void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var particleSystem = laser.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                var emissionModule = particleSystem.emission;
                emissionModule.enabled = isFiring;
            }
            else
            {
                Debug.LogWarning($"Laser {laser.name} does not have a ParticleSystem component!");
            }
        }
    }

    void aimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPt.position - transform.position; // Calculate direction to target point
            Quaternion targetRotation = Quaternion.LookRotation(fireDirection); // Create rotation to face the target

            // Apply the rotation to the laser
            laser.transform.rotation = targetRotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLISION!!!! with " + other.name);
    }
}