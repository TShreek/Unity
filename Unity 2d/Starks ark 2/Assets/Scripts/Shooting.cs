using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    bool isFiring = false;
    [SerializeField] private float targetDist = 100f;
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;

    [SerializeField] private Transform targetPt; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTargetPoint();
        ProcessFiring(); 
        MoveCrosshair();
        aimLasers();
    }

    private void MoveTargetPoint()
    {
        Vector3 targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDist);
        targetPt.position = Camera.main.ScreenToWorldPoint(targetPos);
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
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    void aimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPt.position - this.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = targetRotation;
        }
    }
}