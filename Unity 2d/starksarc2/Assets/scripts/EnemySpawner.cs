using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float timeBWwaves = 0.2f;
    [SerializeField] List<waveConfig> waveConfigs;
    waveConfig currentWave;
    bool isLooping = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemyWaves());
    }
       

    IEnumerator spawnEnemyWaves()
    {
        do
        {
            foreach (waveConfig wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.getEnemyCount(); i++)
                {
                    Instantiate(currentWave.getEnemyPrefab(0), currentWave.getStartPt().position, Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(currentWave.getRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBWwaves);
            }
        }
        while (isLooping);
    }

    public waveConfig getCurrentWave()
    {
        return currentWave;
    }
}
