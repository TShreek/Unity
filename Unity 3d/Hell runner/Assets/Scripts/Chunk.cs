using UnityEngine;
using Random = UnityEngine.Random;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject fencePrefab;
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject coinPrefab;

    private int numRows = 3; 
    private float rowSpacing = 50f / 3f; // Space between rows
    [SerializeField] private float[] lanes = { -2.26f, 1.21f, 5.19f };
    private float laneSpacing2 = 50f / 6f;

    void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        for (int row = 0; row < numRows; row++)  // Loop through rows
        {
            foreach (float laneX in lanes)  // Loop through lanes
            {
                TrySpawnItem(laneX, row * rowSpacing);
            }
        }

        for (int i = 1; i < numRows*2; i += 2)
        {
            for (int j = 0; j < lanes.Length; j++)
            {
                int gen = Random.Range(0, 2);
                Vector3 spawnPosition =  new Vector3(lanes[j],transform.position.y-1.0f,j*laneSpacing2);
                if (gen == 1)
                {
                    Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform);
                }
            }
        }
    }

    private void TrySpawnItem(float x, float z)
    {
        // Higher chance of spawning nothing
        int spawnChoice = Random.Range(0, 4);  

        GameObject prefabToSpawn = null;
        if (spawnChoice == 1) prefabToSpawn = fencePrefab;
        else if (spawnChoice == 3) prefabToSpawn = applePrefab;
        else if (spawnChoice == 2) prefabToSpawn = coinPrefab;

        if (prefabToSpawn != null)  
        {
            Vector3 spawnPosition = new Vector3(x, transform.position.y - 1.0f, transform.position.z + z);
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity, this.transform);
        }
    }
}