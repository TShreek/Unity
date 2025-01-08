using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthScript : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int maxHealth = 100;  // Optional max health cap
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCamShake;
    [SerializeField] bool Enemy;
    bool invincible = false;
    Camerashake camerashake;
    LevelManager levelManager;
    ScoreKeeper scoreKeeper;
    //AudioPlayer audioPlayer;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        if (levelManager == null)
        {
            Debug.Log("LEVEL MANAGER NOT FOUND!!");
        }

        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        if (scoreKeeper == null)
        {
            Debug.Log("SCORE KEEPER NOT FOUND!!");
        }

        camerashake = Camera.main.GetComponent<Camerashake>();
        if (camerashake == null)
        {
            Debug.Log("CAMERA SHAKE NOT FOUND!!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("heart") && !Enemy) // If colliding with a heart object
        {
            IncreaseHealth(20); // Increase health by 20
            Destroy(collision.gameObject); // Destroy the heart object
            return; // Exit the method, since we've handled the heart collision
        }
        if (collision.CompareTag("shield") && !Enemy) // If colliding with a shield object
        {
            StartCoroutine(TemporaryInvincibility()); // Make the player invincible
            Destroy(collision.gameObject); // Destroy the shield object
            return;
        }

        damageDealer damageDealer = collision.GetComponent<damageDealer>();

        if (damageDealer != null && !invincible)
        {
            int damage = damageDealer.getDamage();
            health -= damage;
            KillIfDead();
            if (!Enemy)
            {
                Debug.Log("Player Health: " + health);
            }

            shakeCamera();
        }
        else
        {
            Debug.Log("No damage dealer found on this object: " + collision.gameObject.name);
        }
    }

    private void IncreaseHealth(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth; // Cap health at maxHealth if it exceeds the limit
        }
        Debug.Log("Health increased. Current Health: " + health);
    }

    private void KillIfDead()
    {
        if (health <= 0)
        {
            playHitEffect();
            Destroy(gameObject);
            if (Enemy)
            {
                scoreKeeper.addScore();
            }
            else
            {
                levelManager.EndGame();
                scoreKeeper.resetScore();
            }
        }
    }

    void playHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem hitEff = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hitEff.gameObject, hitEff.main.duration + hitEff.main.startLifetime.constantMax);
        }
    }

    public float getHealth()
    {
        return health;
    }

    void shakeCamera()
    {
        if (camerashake != null && applyCamShake)
        {
            camerashake.play();
        }
    }
    IEnumerator TemporaryInvincibility()
    {
        invincible = true; // Make the player invincible
        Debug.Log("Player is now invincible!");
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.yellow; // Change color to yellow to indicate invincibility
        
        // Optional: You can add visual feedback to show invincibility (e.g., flashing, change color)

        yield return new WaitForSeconds(3f); // Wait for 3 seconds

        invincible = false; // Disable invincibility
        Debug.Log("Player is no longer invincible.");
        renderer.color = Color.white;
    }
}
