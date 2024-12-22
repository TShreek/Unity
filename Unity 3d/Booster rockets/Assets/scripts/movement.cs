using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] float rotSpeed = 60f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] ParticleSystem thrustEffect;
    Rigidbody rigidBody;

    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            processInput();
        }
    }

    public void Kill() {
        isAlive = false;
    }

    public void antiKill()
    {
        isAlive = true;
    }

    private void processInput()
    {
        if (isAlive)
        {
            ProcessThrust();
            ProcessRotation();
        }

    }

    private void ProcessThrust()
    {
        if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.W)))
        {
            Thrust();
        }
        else
        {
            thrustEffect.Stop();
        }
    }

    private void Thrust()
    {
        //transform.Translate(0, upSpeed * Time.deltaTime, 0);
        //Debug.Log("MOVING UP!");
        rigidBody.AddRelativeForce(Vector3.up * Time.deltaTime * boostSpeed, ForceMode.Impulse);
        if (!thrustEffect.isPlaying)
        {
            thrustEffect.Play();
        }
    }

    private void ProcessRotation()
    {
        if ((Input.GetKey(KeyCode.LeftArrow)) || Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D)))
        {
            RotateRight();
        }
    }

    private void RotateRight()
    {
        rigidBody.freezeRotation = true;
        transform.Rotate(-Vector3.forward * Time.deltaTime * rotSpeed);
        rigidBody.freezeRotation = false;
    }

    private void RotateLeft()
    {
        rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotSpeed);
        rigidBody.freezeRotation = false;
        //Debug.Log("ROTATE LEFT");
    }
}
