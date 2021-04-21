using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 7f;
    private float countdown = 2f;

    private int waveNumber = 0;
    void Update()
    {
        if (countdown <= 0f)

        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        //Debug.Log("Wave Incomming!");
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
       
    }
    void SpawnEnemy()
    {
        Quaternion rotation = Quaternion.Euler(0, 90, 0);
        Instantiate(enemyPrefab, spawnPoint.position, rotation);        
    }
}
