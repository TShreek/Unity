using System;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private Player player;
    [SerializeField] private int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            player.DealDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
