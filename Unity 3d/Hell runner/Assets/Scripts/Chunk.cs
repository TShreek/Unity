using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject fencePrefab;
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject coinPrefab;

    private int numRows = 3;
    private float rowSpacing = 50f / 3f;
    [SerializeField] private float[] lanes = { -2.26f, 1.21f, 5.19f };
    private float coinRowSpacing = 50f / 6f;  // More frequent coin rows

    // 🗂️ Track occupied lanes to prevent overlapping spawns
    private Dictionary<(int row, int laneIndex), bool> occupiedLanes = new Dictionary<(int, int), bool>();

    void Start()
    {
        SpawnObstacles();
        SpawnCoinsAndApples();
    }

    // 🚧 Spawns fences and rare apples
    private void SpawnObstacles()
    {
        for (int row = 0; row < numRows; row++)
        {
            int fenceCount = 0; // Limit fences to 2 per row

            for (int laneIndex = 0; laneIndex < lanes.Length; laneIndex++)
            {
                float laneX = lanes[laneIndex];
                TrySpawnObstacle(laneX, row * rowSpacing, row, laneIndex, ref fenceCount);
            }
        }
    }

    // 💰 Spawns coins frequently (and rare apples) in lanes without fences
    private void SpawnCoinsAndApples()
    {
        for (int row = 0; row < numRows * 2; row++) // 6 rows for coins
        {
            for (int laneIndex = 0; laneIndex < lanes.Length; laneIndex++)
            {
                float laneX = lanes[laneIndex];

                // ❌ Skip if this lane already has a fence
                if (occupiedLanes.ContainsKey((row, laneIndex)) && occupiedLanes[(row, laneIndex)])
                    continue;

                float chance = Random.value;

                if (chance < 0.7f) // 70% chance to spawn a coin
                {
                    Vector3 coinPosition = new Vector3(laneX, transform.position.y - 1.0f, transform.position.z + row * coinRowSpacing);
                    Instantiate(coinPrefab, coinPosition, Quaternion.identity, this.transform);
                }
                else if (chance > 0.9f) // 10% chance to spawn an apple
                {
                    Vector3 applePosition = new Vector3(laneX, transform.position.y - 1.0f, transform.position.z + row * coinRowSpacing);
                    Instantiate(applePrefab, applePosition, Quaternion.identity, this.transform);
                }
            }
        }
    }

    private void TrySpawnObstacle(float x, float z, int row, int laneIndex, ref int fenceCount)
    {
        int spawnChoice = Random.Range(0, 10); // 0-9 for finer control
        GameObject prefabToSpawn = null;

        if (spawnChoice < 5 && fenceCount < 2) // 50% chance for fences
        {
            prefabToSpawn = fencePrefab;
            fenceCount++;

            // 🗂️ Mark this lane as occupied to prevent overlapping spawns
            occupiedLanes[(row, laneIndex)] = true;
        }
        else
        {
            // If no fence, mark as unoccupied
            occupiedLanes[(row, laneIndex)] = false;
        }

        if (prefabToSpawn != null)
        {
            Vector3 spawnPosition = new Vector3(x, transform.position.y - 1.0f, transform.position.z + z);
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity, this.transform);
        }
    }
}