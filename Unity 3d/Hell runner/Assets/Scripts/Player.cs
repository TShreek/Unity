using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 3f;
    [SerializeField] private float minX = -5f; // Left boundary
    [SerializeField] private float maxX = 5f;  // Right boundary

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float normalFOV = 60f;   // Default FOV
    [SerializeField] private float maxFOV = 90f;      // FOV when moving fast
    [SerializeField] private float fovChangeSpeed = 5f;

    private Vector2 movement = Vector2.zero;

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
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
    }

    void AdjustCameraFOV()
    {
        float targetFOV = normalFOV;

        if (movement.y > 0) // If moving forward
        {
            targetFOV = Mathf.Lerp(mainCamera.fieldOfView, maxFOV, Time.deltaTime * fovChangeSpeed);
        }
        else
        {
            targetFOV = Mathf.Lerp(mainCamera.fieldOfView, normalFOV, Time.deltaTime * fovChangeSpeed);
        }

        mainCamera.fieldOfView = targetFOV;
    }
}