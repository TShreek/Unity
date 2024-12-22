using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    Rigidbody2D bulletBody;
    PlayerMovementScript player;
    float bulletSpeed = 5f;
    float xSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
        bulletBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovementScript>();

        // Set bullet scale to 0.1 for both x and y while maintaining the direction
        Vector3 bulletScale = new Vector3(Mathf.Sign(player.transform.localScale.x) * 0.1f, 0.1f, 1f);
        transform.localScale = bulletScale;

        // Set the bullet's movement speed based on player's facing direction
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        bulletBody.velocity = new Vector2(xSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "platform")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator SelfDestruct(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    
}
