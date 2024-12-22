using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableSpawner : MonoBehaviour
{
    [SerializeField] float timeBetweenConsumables = 1.0f; // Time between spawning consumables
    [SerializeField] List<GameObject> consumablePrefabs;   // List of consumable prefabs to spawn
    [SerializeField] float spawnHeight = 10f;              // Height at which the consumables spawn
    [SerializeField] float spawnRangeX = 8f;               // Horizontal range within which consumables can spawn
    bool isSpawning = true;

    void Start()
    {
        StartCoroutine(SpawnConsumables());
    }

    IEnumerator SpawnConsumables()
    {
        while (isSpawning)
        {
            // Pick a random consumable from the list
            GameObject consumable = consumablePrefabs[Random.Range(0, consumablePrefabs.Count)];

            // Pick a random X position within the spawn range
            float spawnXPosition = Random.Range(transform.position.x-spawnRangeX, transform.position.x+spawnRangeX);

            // Define the spawn position (falling from the top)
            Vector2 spawnPosition = new Vector2(spawnXPosition, spawnHeight);

            // Instantiate the consumable at the random position
            Instantiate(consumable, spawnPosition, Quaternion.identity);

            // Wait for the next consumable to spawn
            yield return new WaitForSeconds(timeBetweenConsumables);
        }
    }

    public void StopSpawning()
    {
        isSpawning = false; // Call this to stop spawning consumables
    }
}
