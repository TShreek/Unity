using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclesToSpawn;
    private int maxObstacles = 7;
    private List<GameObject> spawnedObstacles = new List<GameObject>();

    float spawnWidth = 4f;
    float spawnInterval = 0.7f;  // Start
    float minSpawnInterval = 0.2f; // Minimum spawn delay
    float difficultyIncreaseRate = 0.1f; // How much spawn time decreases over time

    void Start()
    {
        StartCoroutine(SpawnObstacles());
        StartCoroutine(IncreaseDifficultyOverTime());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            if (obstaclesToSpawn == null || obstaclesToSpawn.Length == 0)
            {
                Debug.LogError("No obstacles assigned in ObstacleSpawner!");
                yield break;
            }

            if (spawnedObstacles.Count < maxObstacles)
            {
                SpawnObstacle();
            }

            // Wait for the current spawn interval before spawning the next one
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstaclesToSpawn.Length);
        GameObject obstaclePrefab = obstaclesToSpawn[randomIndex];

        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnWidth, spawnWidth),
            transform.position.y,
            transform.position.z + 40
        );

        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        spawnedObstacles.Add(obstacle);
        StartCoroutine(DestroyObstacleAfterTime(obstacle, 8f));
    }

    IEnumerator DestroyObstacleAfterTime(GameObject obstacle, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (obstacle != null) 
        {
            spawnedObstacles.Remove(obstacle);
            Destroy(obstacle);
        }
    }

    IEnumerator IncreaseDifficultyOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f); // Every 10 seconds, make it harder
            spawnInterval = Mathf.Max(spawnInterval - difficultyIncreaseRate, minSpawnInterval);
            Debug.Log("Increased difficulty! New spawn interval: " + spawnInterval);
            if (spawnInterval <= 0.5f)
            {
                difficultyIncreaseRate = 0.05f;
            }
        }
    }
}