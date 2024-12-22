using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    waveConfig waveConfig;  // Corrected the typo here
    List<Transform> wayPoints;
    int wayPointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waveConfig = enemySpawner.getCurrentWave();
        wayPoints = waveConfig.getWayPts();  // Corrected usage of waveConfig
        transform.position = wayPoints[wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        followPath();
    }

    private void followPath()
    {
        if (wayPointIndex < wayPoints.Count)
        {
            Vector3 targetPos = wayPoints[wayPointIndex].position;
            float delta = waveConfig.getMVSpeed() * Time.deltaTime;  // Corrected usage of waveConfig
            transform.position = Vector2.MoveTowards(transform.position, targetPos, delta);

            if (transform.position == targetPos)
            {
                wayPointIndex ++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
