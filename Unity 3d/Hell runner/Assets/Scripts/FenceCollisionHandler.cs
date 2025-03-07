using System;
using UnityEngine;
    public class FenceCollisionHandler : MonoBehaviour
    {
        private Player player;
        [SerializeField] private int damage= 10;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            player = FindFirstObjectByType<Player>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag("Fence"))
            {
                Debug.Log("COlisSion with" +  other.transform.name);
                player.DealDamage(damage);
            }
        }
    }

