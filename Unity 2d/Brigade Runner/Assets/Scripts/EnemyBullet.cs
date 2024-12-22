using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D bulletBody;
    [SerializeField] float bulletspeed = 5f;
    PlayerMovementScript player;
    float xspeed;

    void Start()
    {

        bulletBody = GetComponent<Rigidbody2D>();
        // Ensure bullet velocity is set when instantiated
        SetBulletDirection();
        player = FindObjectOfType<PlayerMovementScript>();
        Invoke("SelfDestruct", 10);
    }

    void SetBulletDirection()
    {
        // Get the direction based on the scale of the enemy
        EnemyMovement enemy = FindObjectOfType<EnemyMovement>();
        if (enemy != null)
        {
            xspeed = enemy.transform.localScale.x * bulletspeed;
        }
        else
        {
            xspeed = bulletspeed; // Default speed if no enemy found
        }

        // Set the velocity once when the bullet is instantiated
        bulletBody.velocity = new Vector2(xspeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            player.die();
        }
        else if (collision.gameObject.CompareTag("platform"))
        {
            Destroy(gameObject);
           
        }
    }
    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
