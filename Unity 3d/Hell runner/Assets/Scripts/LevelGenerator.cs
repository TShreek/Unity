using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int chunkAmmount = 4;
    [SerializeField] private float chunkLength = 50f; // Length of each chunk

    private List<GameObject> chunks = new List<GameObject>(); // Store chunks
    private Camera mainCamera; // Reference to main camera

    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
        generateChunks();
    }

    private void generateChunks()
    {
        for (int i = 0; i < chunkAmmount; i++)
        {
            var chunk = Instantiate(chunkPrefab, transform.position + new Vector3(0, 0, i * chunkLength), Quaternion.identity);
            chunks.Add(chunk);
        }
    }

    void Update()
    {
        moveChunks();
        recycleChunks();
    }

    void moveChunks()
    {
        foreach (var chunk in chunks)
        {
            chunk.transform.Translate(-Vector3.forward * (Time.deltaTime * moveSpeed)); // Move backward
        }
    }

    void recycleChunks()
    {
        if (chunks.Count == 0) return; // Safety check

        GameObject firstChunk = chunks[0]; // Get the first chunk

        // If the chunk is behind the camera, recycle it
        if (firstChunk.transform.position.z < mainCamera.transform.position.z - chunkLength)
        {
            chunks.RemoveAt(0); // Remove from list
            Destroy(firstChunk); // Destroy the old chunk

            // Create a new chunk at the end of the last chunk
           // GameObject lastChunk = chunks[chunks.Count - 1]; // Get last chunk
            Vector3 newPos = new Vector3(0, 0, mainCamera.transform.position.z + chunkLength*chunkAmmount);
            GameObject newChunk = Instantiate(chunkPrefab, newPos, Quaternion.identity);
            chunks.Add(newChunk); // Add new chunk to the list
        }
    }
}