using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmt = 0.12f;
    SurfaceEffector2D surfaceEffector2D;
    float boostspeed = 12.0f;
    public int score = 0;
    private bool isInAir = false;
    private float airTimeCounter = 0f;
    private ScoreManager scoreManager;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        scoreManager = ScoreManager.instance;
    }

    void Update()
    {
        rotateSprite();
        respondToBoost();
        TrackAirTime();
    }

    void TrackAirTime()
    {
        if (isInAir)
        {
            airTimeCounter += Time.deltaTime;
            if (airTimeCounter >= 0.1f)
            {
                scoreManager.AddScore(1);
                score += 1; // Add 1 point for every 0.1 seconds in air
                airTimeCounter = 0f; // Reset counter
            }
        }
    }

    void respondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostspeed;
        }
        else
        {
            surfaceEffector2D.speed = 8f;
        }
    }

    void rotateSprite()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmt);
            if (isInAir)
            {
                scoreManager.AddScore(10);
                score += 10; // Add 10 points for rotating in air
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmt);
            if (isInAir)
            {
                scoreManager.AddScore(10);
                score += 10; // Add 10 points for rotating in air
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            isInAir = false;
            airTimeCounter = 0f; // Reset air time counter when touching ground
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            isInAir = true;
        }
    }
}
