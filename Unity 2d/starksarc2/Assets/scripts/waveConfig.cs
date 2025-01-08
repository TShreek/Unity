using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "new wave points")]
public class waveConfig : ScriptableObject
{
    [SerializeField] GameObject pathPrefab;  // A reference to the path (containing waypoints)
    [SerializeField] float moveSpeed = 2f;  // Speed at which the enemy moves
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] float spawnVariance = 0.5f;
    [SerializeField] float minimumSpawnTime = .5f;

    // Return a list of waypoints (Transform components)
    public int getEnemyCount()
    {
        return enemyPrefabs.Count;
    }
    public float getRandomSpawnTime()
    {
        float spawnT = Random.Range(spawnInterval - spawnVariance, spawnInterval + spawnVariance);
        return Mathf.Clamp(spawnT, minimumSpawnTime, float.MaxValue);
    }

    public GameObject getEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public List<Transform> getWayPts()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    public Transform getStartPt()
    {
        return pathPrefab.transform.GetChild(0);  
    }

    // Return the movement speed
    public float getMVSpeed()
    {
        return moveSpeed;
    }
}
