using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinBheaviour : MonoBehaviour
{
    public int coinsCollected;
    [SerializeField] AudioClip coinSound;
    GameSession GameSession;
    int coins;

    private void Awake()
    {
        coinsCollected = 0;
        GameSession = FindObjectOfType<GameSession>();
        coins = GameSession.coins;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position);
            Destroy(gameObject);
            if (GameSession)
            {
                GameSession.AddCoins(100);
            }

        }
    }
}
