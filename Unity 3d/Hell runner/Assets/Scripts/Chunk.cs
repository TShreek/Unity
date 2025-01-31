using UnityEngine;
using Random = UnityEngine.Random;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject fencePrefab;
    private int numOfFences = 3;
    private float toAdd = 50f / 3f; // Ensure float division
    [SerializeField] private float[] lanes = { -1.36f, 2.21f, 5.31f };

    void Start()
    {
        spawnFence();
    }

    private void spawnFence()
    {
        for (int i = 0; i < numOfFences; i++)
        {
            InstantiateFence(i * toAdd);
        }
    }

    private void InstantiateFence(float z)
    {
        int FenceIndex = Random.Range(0, lanes.Length); // Get a valid lane index
        float x = lanes[FenceIndex]; // Pick a lane position
        Vector3 spawnPosition = new Vector3(transform.position.x + x, transform.position.y - 1.0f, transform.position.z + z);
        Instantiate(fencePrefab, spawnPosition, Quaternion.identity,this.transform); 
    }
}