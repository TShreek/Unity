using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D enemyBody;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    float movespeed = .5f;

    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        // Schedule fire to be called every 5 seconds
        InvokeRepeating("fire", 3f, 2f);
    }

    void Update()
    {
        // Update enemy velocity
        enemyBody.velocity = new Vector2(movespeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Reverse direction and flip the enemy sprite
        movespeed *= -1;
        flipEnemy();
    }

    void flipEnemy()
    {
        transform.localScale = new Vector2(-Mathf.Sign(enemyBody.velocity.x), 1f);
    }

    void fire()
    {
        Instantiate(bullet, gun.position, transform.rotation);
        //Debug.Log("ENEMY FIIIREE!!");
    }
}
