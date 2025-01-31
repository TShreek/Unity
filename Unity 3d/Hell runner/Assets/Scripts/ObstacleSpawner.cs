using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclesToSpawn;
    private int maxObstacles = 5;
    private List<GameObject> spawnedObstacles = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true) // Keeps the coroutine running
        {
            if (obstaclesToSpawn == null || obstaclesToSpawn.Length == 0)
            {
                Debug.LogError("No obstacles assigned in ObstacleSpawner!");
                yield break; // Stop the coroutine if there's nothing to spawn
            }

            if (spawnedObstacles.Count < maxObstacles)
            {
                int randomIndex = Random.Range(0, obstaclesToSpawn.Length); // Get a random index safely
                GameObject obstaclePrefab = obstaclesToSpawn[randomIndex];

                GameObject obstacle = Instantiate(
                    obstaclePrefab, 
                    transform.position + new Vector3(Random.Range(-3f, 3f), 0, 40), 
                    Quaternion.identity
                );

                spawnedObstacles.Add(obstacle);
                StartCoroutine(DestroyObstacleAfterTime(obstacle, 10f));
            }

            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator DestroyObstacleAfterTime(GameObject obstacle, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (obstacle != null) 
        {
            spawnedObstacles.Remove(obstacle); // Remove from list
            Destroy(obstacle);
        }
    }
}